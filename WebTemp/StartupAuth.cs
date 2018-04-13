using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTempp
{
    public partial class Startup
    {
        public static void ConfigureAuth(IAppBuilder app)
        {
            var option = new CookieAuthenticationOptions()
            {
                CookieName = "CyberAcademy",
                LoginPath = new PathString("/Signin/Signin")
            };
            app.UseCookieAuthentication(option);
        }
    }
}