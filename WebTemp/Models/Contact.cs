using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTemp.Models
{
    public class Contact : IdentityUser
    {
        private Contact()
        {

        } 
    public static Contact Create(string username, DateTime createdOn)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException("Username is Empty");

            return new Contact()
            {
                UserName = username,
                Name = "Winnie",
                Email = username,
                IsActive = true,
                EmailConfirmed = true,
                CreatedOn = createdOn
            };
        }

        public string ProfileImage { get; set; }
        public string Name { get; set; }
        public string Product { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
