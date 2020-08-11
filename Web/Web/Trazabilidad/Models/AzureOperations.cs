namespace Trazabilidad.Models
{
    using Microsoft.Azure.ActiveDirectory.GraphClient;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Resources.Strings;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class AzureOperations
    {
        private static string clientId = ConfigurationManager.AppSettings["ida:ClientId"];
        private static string appKey = ConfigurationManager.AppSettings["ida:ClientSecret"];
        private static string aadInstance = ConfigurationManager.AppSettings["ida:AADInstance"];
        private static string graphResourceID = "https://graph.windows.net";

        public static async Task<string> GetTokenForApplication()
        {
            string signedInUserID = ClaimsPrincipal.Current.FindFirst(ClaimTypes.NameIdentifier).Value;
            string tenantID = ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/tenantid").Value;
            string userObjectID = ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier").Value;
            try
            {
                // get a token for the Graph without triggering any user interaction (from the cache, via multi-resource refresh token, etc)
                var credential = new ClientCredential(clientId, appKey);

                AuthenticationResult silentResult;
                UserIdentifier userIdentifier = new UserIdentifier(userObjectID, UserIdentifierType.RequiredDisplayableId);
                // initialize AuthenticationContext with the token cache of the currently signed in user, as kept in the app's database
                var authenticationContext = new AuthenticationContext(aadInstance + tenantID, new ADALTokenCache(signedInUserID));
                // silentResult = await authenticationContext.AcquireTokenSilentAsync(graphResourceID, clientcred, userIdentifier);

                silentResult = await authenticationContext.AcquireTokenAsync(aadInstance, credential);
                return silentResult.AccessToken;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<List<IUser>> GetUsersFromAD(string groupId)
        {
            string tenantID = ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/tenantid").Value;
            string userObjectID = ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier").Value;
            try
            {
                Uri servicePointUri = new Uri(graphResourceID);
                Uri serviceRoot = new Uri(servicePointUri, tenantID);
                ActiveDirectoryClient activeDirectoryClient = new ActiveDirectoryClient(serviceRoot,
                      async () => await GetTokenForApplication());

                var groups = await activeDirectoryClient.Groups
                    .Where(u => groupId.Equals(u.ObjectId))
                    .Expand(x => x.Members)
                    .ExecuteAsync();

                var users = new List<IUser>();

                do
                {
                    foreach (var group in groups.CurrentPage)
                    {
                        users.AddRange(group.Members.CurrentPage.Select(x => x as IUser).ToList());
                    }
                    groups = await groups.GetNextPageAsync();
                }
                while (groups != null && groups.MorePagesAvailable);

                return users;
            }

            //TODO: Catch clauses!
            catch (AdalException ex)
            {
                // Return to error page.
                //return View("Error");
                throw ex;
            }
            // if the above failed, the user needs to explicitly re-authenticate for the app to obtain the required token
            catch (Exception ex)
            {
                return null;
                //return View("Relogin");
                //throw ex;
            }
        }

        //public static async Task<List<IUser>> GetCrewmen()
        //    => await GetUsersFromAD(AzureGroups.PlatformCrew);

        public static async Task<Tuple<string, string, string>> GetUserMissingInfo(string azureId)
        {
            IUser user;
            string tenantID = ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/tenantid").Value;
            string userObjectID = ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier").Value;
            try
            {
                Uri servicePointUri = new Uri(graphResourceID);
                Uri serviceRoot = new Uri(servicePointUri, tenantID);
                ActiveDirectoryClient activeDirectoryClient = new ActiveDirectoryClient(serviceRoot, async () => await GetTokenForApplication());

                user = await activeDirectoryClient.Users.Where(x => x.ObjectId.Equals(azureId)).ExecuteSingleAsync();

                var encodedImage = string.Empty;
                try
                {
                    var photo = await user.ThumbnailPhoto.DownloadAsync();
                    using (MemoryStream s = new MemoryStream())
                    {
                        photo.Stream.CopyTo(s);
                        encodedImage = Convert.ToBase64String(s.ToArray());
                    }
                }
                catch (Exception ex)
                {
                    encodedImage = null;
                }

                return Tuple.Create(user.JobTitle, user.PhysicalDeliveryOfficeName, encodedImage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}