using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTemp.Models;

namespace WebTemp.Controllers.DataAccess
{
    public class AppDbContext:IdentityDbContext<AppUser,AppRole,Guid,AppUserLogin,AppUserRole,AppUserClaim>
    {
        public AppDbContext() : base($"name={nameof(AppDbContext)}")
        {

        }
    }
}