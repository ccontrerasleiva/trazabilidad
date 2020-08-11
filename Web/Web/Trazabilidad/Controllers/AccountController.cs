using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.IdentityModel.Tokens;
using Trazabilidad.Models;
using System.Configuration;

namespace Trazabilidad.Controllers
{
    public class AccountController : Controller
    {
        public void SignIn()
        {
            // Send an OpenID Connect sign-in request.
            if (!Request.IsAuthenticated)
            {
                HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties { RedirectUri = "/" },
      OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
        }

        public ActionResult Index()
            {
            return View();
            //return PartialView("~/Views");
        }

        public void SignOut()
        {
            string callbackUrl = Url.Action("SignOutCallback", "Account", routeValues: null, protocol: Request.Url.Scheme);

            HttpContext.GetOwinContext().Authentication.SignOut(
                new AuthenticationProperties { RedirectUri = callbackUrl },
                OpenIdConnectAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);

            string signedInUserID =
                ClaimsPrincipal.Current.FindFirst(ClaimTypes.NameIdentifier).Value;
            ADALTokenCache adalTokenCache = new ADALTokenCache(signedInUserID);
            adalTokenCache.Clear();

            //Delete cookies from user session!
            foreach (string cookie in Request.Cookies.AllKeys)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }
        }

        public ActionResult SignOutCallback()
        {

            if (Request.IsAuthenticated)
            {
                var user = (System.Security.Claims.ClaimsIdentity)User.Identity;

                //var ss = user.Claims.FirstOrDefault(c => c.Value == admi).Value;
                if (user.HasClaim("groups", Resources.Strings.AzureGroups.PlatformAdmin) || user.HasClaim("groups", Resources.Strings.AzureGroups.PlatformOperacion) || user.HasClaim("groups", Resources.Strings.AzureGroups.PlatformExterno))
                {
                    // Redirect to home page if the user is authenticated.
                    return RedirectToAction("Index", "Armado");
                }
                else
                {
                    return RedirectToAction("Unauthorized", "Account");
                }

            }
            else
            {
                return RedirectToAction("SignIn", "Account");
                //return RedirectToAction("RefreshSession", "UserProfile");
                
            }
            //return View();

        }

  

        public ActionResult Unauthorized() => View();
    }
}