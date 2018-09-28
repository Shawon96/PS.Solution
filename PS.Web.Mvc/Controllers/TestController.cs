using PS.Core.Entities.Other;
using PS.Core.Entities.Owner;
using PS.Core.Service.Services;
using PS.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PS.Web.Mvc.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public string GetRat()
        {
            int pId = 7;
            PsDbContex db = new PsDbContex();
            var rat = db.PlaceReviews.Where(r => r.ToPlaceId == pId).Average(r => r.Rating);

            return rat.ToString();
        }
        public string Chk()
        {
            PlaceReview rev = new PlaceReview()
            {
                CarUserId = 2,
                Time = DateTime.Today.Date,
                ToPlaceId = 7,
                Rating = 5,
                Comment = "OK"
            };

            PsDbContex db = new PsDbContex();
            var x = db.PlaceReviews.Add(rev);
            db.SaveChanges();

            return x.ID.ToString();
        }
        public string test()
        {
            Test Service = new Test();
            if (Service.registerAdmin())
            {
                return "ok";
            }
            else
            {
                return "Error";
            }
           
        }

        public string DbChk()
        {
            PlaceService service = new PlaceService();
            List<ParkingPlace> data = new List<ParkingPlace>();
            data = service.getMatchedPlaces("AIUB");

            return data[0].SpotName.ToString();
        }
        public ActionResult Login()
        {
            return View("login");
        }

        public ActionResult SignUp()
        {
            return View("signup");
        }
        [HttpPost]
        public ActionResult Register()
        {
            return View();
        }
    }
}