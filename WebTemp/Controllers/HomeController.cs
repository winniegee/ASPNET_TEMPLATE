using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace WebTemp.Controllers
{
    [Authorize]
    [RequireHttps]
    public class  HomeController : Controller
    {
        public HomeController()
        {
               
        }
        public ActionResult Error404()
        {
            ViewBag.Message = "Page Not found";
            return View();

        }
        public string GetDate()
        {
            return DateTime.Now.ToLongDateString();
        }
        // GET: Home
        public ActionResult Index()
        {
            var claimsPrincipal = this.User.Identity as ClaimsIdentity;
            var claims = claimsPrincipal.FindFirst("PassportUrl");
            // ViewBag.ProfileUrl = Claim.Value;
            ViewData["SalesAnalyticsCaptions"] = "Sales Analytics";
            return View();
        }
    }
}