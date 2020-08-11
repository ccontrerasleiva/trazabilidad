namespace Trazabilidad.Helpers
{
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.OpenIdConnect;
    using Trazabilidad.Models;
    using Resources.Strings;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class AzureADGBACAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var identity = (System.Security.Claims.ClaimsIdentity)filterContext.RequestContext.HttpContext.User.Identity;

            if (!identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                    { "action", "Login" },
                    { "controller", "Account" } });
                return;
            }

            /*Create permission string based on the requested controller
              name and action name in the format 'controllername-action'*/

            var controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var action = filterContext.ActionDescriptor.ActionName;

            string requestedUri = $"{controller}/{action}";

            //Challenge auth if session token is invalid!
            if (!identity.IsAuthenticated || !(identity is System.Security.Claims.ClaimsIdentity) || identity.Claims.Count() == 0)
                filterContext.HttpContext.GetOwinContext().Authentication.Challenge(
                    new AuthenticationProperties { RedirectUri = requestedUri },
                    OpenIdConnectAuthenticationDefaults.AuthenticationType);

            //Admin
            if (identity.IsInGroup(AzureGroups.PlatformAdmin))
                return;

            //RRHH
            if (identity.IsInGroup(AzureGroups.PlatformHumanResources) && !controller.ToLower().Equals("users"))
                filterContext.Result = Unauthorised;

            //CGO
            if (!identity.IsInGroup(AzureGroups.PlatformManager))
            {
                /*User doesn't have the required permission and is not a SysAdmin, return
                    custom '401 Unauthorized' access error. Since we are setting
                    filterContext.Result to contain an ActionResult page, the controller's
                    action will not be run.

                    The custom '401 Unauthorized' access error will be returned to the
                    browser in response to the initial request.*/
                filterContext.Result = Unauthorised;
            }

            /*If the user has the permission to run the controller's action, then
              filterContext.Result will be uninitialized and executing the controller's
              action is dependant on whether filterContext.Result is uninitialized.*/
        }

        private static ActionResult Unauthorised
            => new RedirectToRouteResult(
                    new RouteValueDictionary {
                    { "action", "Unauthorized" },
                    { "controller", "Account" } });
    }

    public static class AzureGroupExtensions
    {
        private readonly static string _groupsKey = "groups";

        public static bool IsInGroup(this System.Security.Claims.ClaimsIdentity user, string groupId)
            => user.HasClaim(_groupsKey, groupId);
    }
}