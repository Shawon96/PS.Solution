using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PS.Core.Service.Services;
using PS.Infrastructure;

namespace PS.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            /*AuthenticationService service = new AuthenticationService();
            if (service.login("ift_khan", "ift123") != 0)
                return "You are Loged-In!";
            return "Invalid Username or Password!";*/

            /*Test service = new Test();
            if(service.registerAdmin())
                return "Wellcome Done!";
            return "Data not Inserted!";*/

            /*Test service = new Test();
            if(service.blockUser(2))
                return "Wellcome Done!";
            return "Something Went Wrong!";*/
            return "Home";
        }
    }
}