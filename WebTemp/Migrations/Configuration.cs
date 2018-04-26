namespace WebTemp.Migrations
{
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebTemp.Models;
    using WebTempp;

    internal sealed class Configuration : DbMigrationsConfiguration<WebTemp.Controllers.DataAccess.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebTemp.Controllers.DataAccess.AppDbContext context)
        {
            string username = "osezuahofure@gmail.com";
            string password = "admin";
            string role = "Admin";
            var userMgr = Startup.UserManagerFactory.Invoke();
            var userRole = Startup.RoleManagerFactory.Invoke();
            if (userMgr.FindByName(username) != null)
                return;
            var appUser = new AppUser()
            {
                UserName = username,
                CreatedOn = DateTime.Now
            };
            var result = userMgr.Create(appUser, password);
            if (!userRole.RoleExists(role))
            {
                var irole = new AppRole()
                {
                    Name = role
                };
                userRole.Create<AppRole, Guid>(irole);
            }
            if(!userMgr.IsInRole<AppUser, Guid>(appUser.Id, role)){
                userMgr.AddToRole<AppUser, Guid>(appUser.Id, role);
            }




            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
