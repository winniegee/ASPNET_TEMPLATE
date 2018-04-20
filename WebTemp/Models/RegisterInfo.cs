using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebTemp.Models
{
    public class RegisterInfo
    {
        public string EmailAddress { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}