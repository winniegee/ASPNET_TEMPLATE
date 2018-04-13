using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebTemp;
using Microsoft.Owin.Host.SystemWeb;
using WebTemp.Controllers;
using WebTempp;

[assembly: OwinStartup(typeof(WebTempp.Startup))]
namespace WebTempp
{
    public partial class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.Configure(GlobalFilters.Filters);
            ConfigureAuth(app);
        }
    }
}