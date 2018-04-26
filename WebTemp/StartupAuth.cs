using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using WebTemp.Models;
using WebTemp.Controllers.DataAccess;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebTempp
{
    public partial class Startup
    {
        public static Func<UserManager<AppUser, Guid>> UserManagerFactory { get; private set; } = Create;
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
        public static UserManager<AppUser, Guid> Create()
        {
            var dbContext = new AppDbContext();
            var store = new UserStore<AppUser, AppRole, Guid, AppUserLogin, AppUserRole, AppUserClaim>(dbContext);
            var usermanager = new UserManager<AppUser, Guid>(store);

            usermanager.UserValidator = new UserValidator<AppUser,Guid>(usermanager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false,
            };
            usermanager.PasswordValidator = new PasswordValidator()
            {
                RequiredLength = 4,
                RequireDigit = false,
                RequireUppercase = false
            };
            return usermanager;
        }
        public static Func<RoleManager<AppRole, Guid>> RoleManagerFactory { get; private set; } = RoleCreate;
        public static  RoleManager<AppRole, Guid> RoleCreate()
        {
            var dbContext = new AppDbContext();
            var store = new RoleStore<AppRole, Guid,  AppUserRole>(dbContext);
            var rolemanager = new RoleManager<AppRole, Guid>(store);
            return rolemanager;
        }
    }
}