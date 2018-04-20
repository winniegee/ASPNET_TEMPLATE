using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebTemp.Models
{
    public class SigninInfo
    {
        [Required(ErrorMessage = "Username should be a valid email.")]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}