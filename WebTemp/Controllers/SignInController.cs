using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTemp.Controllers
{
    [AllowAnonymous]
    public class SigninController : Controller
    {
        // GET: Login
        public ActionResult Signin()
        {
            return View();
        }
    }
}