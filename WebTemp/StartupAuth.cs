using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
namespace WebTempp
{
    public partial class Startup
    {
        public static void ConfigureAuth(IAppBuilder app)
        {
            var option = new CookieAuthenticationOptions()
            {
                AuthenticationType = "ApplicationCookie",
                CookieName = "CyberAcademy",
                LoginPath = new PathString("/Signin/Signin")
            };

            app.UseCookieAuthentication(option);
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            app.UseGoogleAuthentication(
               clientId: "926314037407-6fo0c4de1meka6nbroa2n362n7ddnm5m.apps.googleusercontent.com",
               clientSecret: "EL2rOz7-wqOu1rc1BEpvgG3y");
        }
    }
}