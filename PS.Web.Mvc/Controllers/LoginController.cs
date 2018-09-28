using PS.Core.Entities.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;
using PS.Core.Service.Services;

namespace integratingViews.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if(Session["type"]== null) return View("login");

            if (Session["type"].ToString() == "0")
            {
                return RedirectToAction("index","Admin");
            }
            else if (Session["type"].ToString() == "1")
            {
                return RedirectToAction("index", "Users");
            }
            else if (Session["type"].ToString() == "2")
            {
                return RedirectToAction("index", "Owner");
            }

            else
                return View("login");

        }
        [HttpPost]
        public ActionResult Index(LogInInfo usr)
        {
            AuthService service = new AuthService();
            int UserId = service.login(usr.Username, usr.Password);
            if (UserId == 0)
            {
                return RedirectToAction("index", "Login");
            }
            
            else
            {

                int type = service.getType(UserId);
                Session["USERID"] = UserId;
                Session["TYPE"] = type;

                if(type==1)
                {
                    return RedirectToAction("index", "Users");
                }
                else if(type==2)
                {
                    return RedirectToAction("index", "Owner");
                }
                else
                {

                }
            }
            return View("login");
        }
        public ActionResult OwnerSignup()
        {
            return View("ownerSignup");
        }
        public ActionResult UserSignup()
        {
            return View("userSignup");
        }


        public ActionResult Logout()
        {
            Session["type"] = -1;
            Session["USERID"] = -1;

            return RedirectToAction("index", "Login");
        }
    }

}