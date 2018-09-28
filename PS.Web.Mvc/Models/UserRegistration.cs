using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PS.Web.Mvc.Models
{
    public class UserRegistration
    {
        public string Username { set; get; }
        public string Password { set; get; }
        public string ConfirmPassword { set; get; }
        public string Mobile { set; get; }
        public string Email { set; get; }
        public string CarModel { get; set; }
        public string LicensNumber { get; set; }
    }
}