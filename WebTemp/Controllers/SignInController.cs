using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebTemp.Models;
using WebTempp;

namespace WebTemp.Controllers
{
    [AllowAnonymous]
    public class SigninController : Controller
    {
        private UserManager<AppUser, Guid> _userManager;
        public SigninController()
        {
            _userManager = Startup.UserManagerFactory.Invoke();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Signout()
        {
            var ctxt = this.Request.GetOwinContext();
            ctxt.Authentication.SignOut("ApplicationCookie");

            return Redirect("Signin");
        }
       

        // GET: Signin
        [HttpPost]
        public ActionResult Signin(SigninInfo data)
        {
            string username = "osezuahofure@gmail.com";
            string password = "admin";


            if (this.ModelState.IsValid)
            {
                if (username.Equals(data.Username) && password.Equals(data.Password))
                {
                    ClaimsIdentity claimsIdentity =
                        new ClaimsIdentity("ApplicationCookie");
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, data.Username));
                    claimsIdentity.AddClaim(new Claim("PassportUrl", Url.Content("~/images/profile.png")));


                    var ctxt = this.Request.GetOwinContext();
                    ctxt.Authentication.SignIn(claimsIdentity);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    this.ModelState.AddModelError("", "Username or password is invalid");
                }
            }
            return View(data);
         }
        [HttpGet]
        public ActionResult Signin()
        {
            return View();
        }
        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("Index", "Home");
            }

            return returnUrl;
        }
    }
}