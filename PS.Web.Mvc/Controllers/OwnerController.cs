using PS.Core.Entities.Other;
using PS.Core.Entities.Owner;
using PS.Core.Entities.User;
using PS.Core.Service.Services;
using PS.Web.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace integratingViews.Controllers
{
    public class OwnerController : Controller
    {
        // GET: Owner
        public ActionResult Index()
        {
           List<ParkingPlace> places = new List<ParkingPlace>();
            if (Session["type"].ToString() == "2")
            {
                PlaceService pService = new PlaceService();
                int id = Convert.ToInt32(Session["USERID"]);
                places = pService.getAllPlaces(id);
                return View("home", places);
            }

            else
            {
                return RedirectToAction("index", "Login");
            }
            
        }
        public ActionResult Add()
        {
            if (Session["type"].ToString() == "2")
                return View("add");
            else
            {
                return RedirectToAction("index", "Login");
            }
        }
        [HttpPost]
        public ActionResult Add(PlaceInfo placeIn)
        {
            /*
            string str="";
            str += "$" + placeIn.SpotName;
            str += "$" + placeIn.SpotLocation;
            str += "$" + placeIn.PricePerHour;
            str += "$" + placeIn.Lat;
            str += "$" + placeIn.Lon;
            str += "$" + placeIn.NewFacility;
            str += "$" + placeIn.Option1;
            str += "$" + placeIn.Option2;
            str += "$" + placeIn.Option3;

            int count=0;
            for(int i=0; i<placeIn.NewFacility.Length;i++)
            {
                if (placeIn.NewFacility[i].ToString() == "\n")
                    count++;
            }
            return str+"$"+count;
            */
            ParkingPlace ps = new ParkingPlace
            {
                SpotName = placeIn.SpotName,
                SpotLocation = placeIn.SpotLocation,
                Capacity = placeIn.Capacity,
                PricePerHour = placeIn.PricePerHour,
                Lat = placeIn.Lat,
                Lon = placeIn.Lon,
                IsBlocked = 1,
                ID = 10,
                OwnerId = Convert.ToInt32(Session["USERID"])
                
            };

            PlaceService pService = new PlaceService();
            int pid = pService.createPlace(ps);

            List<string> des = new List<string>();

            string tmp = "";
            if (placeIn.NewFacility == null) { placeIn.NewFacility = ""; }
            for(int i=0; i<placeIn.NewFacility.Length;i++)
            {
                if (placeIn.NewFacility[i].ToString() == "\n")
                {
                    des.Add(tmp);
                    tmp = "";
                }
                else tmp += placeIn.NewFacility[i];
            }

            Facility f = new Facility
            {
                ID = 10,
                OwnerId = Convert.ToInt32(Session["USERID"]),
                Popularity = pid,
            };

            FacilityService fService = new FacilityService();
            for (int i=0;i<des.Count ;i++)
            {
                f.Description = des[i];
                fService.setNewFacilty(f);
            }

            return RedirectToAction("index","Owner");
        }
        public ActionResult ChangePass()
        {
            if (Session["type"].ToString() == "2")
                return View("changepass");
            else
            {
                return RedirectToAction("index", "Login");
            }
            
        }
        public ActionResult EditProfile()
        {
            if (Session["type"].ToString() == "2")
                return View("edit");
            else
            {
                return RedirectToAction("index", "Login");
            }
            
        }
        public ActionResult EditPlace(ParkingPlace aPlace)
        {
            PlaceService service = new PlaceService();
            service.editPlace(aPlace,10);
            return RedirectToAction("index", "Owner");
        }
        public ActionResult Delete(int id)
        {
            PlaceService service = new PlaceService();
            service.deletePlace(id);
            return RedirectToAction("index", "Owner");
        }
        public ActionResult _Profile()
        {
            if (Session["type"].ToString() == "2")
                return View("profile");
            else
            {
                return RedirectToAction("index", "Login");
            }
        
        }
        public ActionResult requests()
        {
            if (Session["type"].ToString() == "2")
            {
                List<Booking> books = new List<Booking>();
                List<Subscriptions> subs = new List<Subscriptions>();

                OwnerBookingManagementService owservice = new OwnerBookingManagementService();
                int id = Convert.ToInt32(Session["USERID"]);

                books = owservice.getAllBookings(id);
                subs = owservice.getAllSubscriptions(id);

                List<OwnerBookingModel> data = new List<OwnerBookingModel>();
                /*
                 public int isBook { get; set; }

                public int BookId { get; set; }
                public string ParkerName { get; set; }
                public string PlaceName { get; set; }
                public DateTime Date { get; set; }
                public DateTime From { get; set; }
                public DateTime To { get; set; }

                public int IsPending { get; set; }
                 */
                PlaceService pserv = new PlaceService();
                for (int i = 0; i < books.Count; i++)
                {
                    int uId = books[i].UserId, pId = books[i].PlaceId;

                    AuthService srv = new AuthService();
                    string parkerName = srv.getUsername(uId);

                    PlaceService psrv = new PlaceService();
                    ParkingPlace place = psrv.getPlaceInfo(pId);

                    OwnerBookingModel mod = new OwnerBookingModel();

                    mod.isBook = 1; //means book type
                    mod.BookId = books[i].ID;
                    mod.ParkerName = parkerName;
                    mod.PlaceName = place.SpotName;

                    mod.IsPending = books[i].IsPending;
                    
                    data.Add(mod);
                }


                for (int i = 0; i < subs.Count; i++)
                {
                    int uId = subs[i].UserId, pId = subs[i].PlaceId;

                    AuthService srv = new AuthService();
                    string parkerName = srv.getUsername(uId);

                    PlaceService psrv = new PlaceService();
                    ParkingPlace place = psrv.getPlaceInfo(pId);

                    OwnerBookingModel mod = new OwnerBookingModel();

                    mod.isBook = 0; //means book type
                    mod.BookId = subs[i].ID;
                    mod.ParkerName = parkerName;
                    mod.PlaceName = place.SpotName;

                    mod.Date = subs[i].Date;
                    mod.From = subs[i].Start;
                    mod.To = subs[i].End;
                    mod.IsPending = subs[i].IsPending;

                    data.Add(mod);
                }

                
                return View("requests",data);
            }
                
            else
            {
                return RedirectToAction("index", "Login");
            }
            
        }
        public ActionResult reviews()
        {
            //return Session["USERID"].ToString();
            if (Session["type"].ToString() == "2")
            {
                ReviewService service = new ReviewService();
                List<Review> revs = new List<Review>();
                int id = Convert.ToInt32(Session["USERID"]);
                revs = service.getAllReviews(id);

                List<ReviewViewModel> res = new List<ReviewViewModel>();


                AuthService atsr = new AuthService();
                for (int i = 0; i < revs.Count; i++)
                {
                    ReviewViewModel tmp = new ReviewViewModel();
                    tmp.Time = revs[i].Time;
                    tmp.Rating = revs[i].Rating;
                    tmp.Comment = revs[i].Comment;

                    if (revs[i].FromUserId == id)
                    {
                        tmp.IsToMe = 0;
                        tmp.Who = atsr.getUsername(revs[i].ToUserId);
                    }
                    else
                    {
                        tmp.IsToMe = 1;
                        tmp.Who = atsr.getUsername(revs[i].FromUserId);
                    }

                    res.Add(tmp);
                }
                return View("reviews", res);
            }

            else
            {
                return RedirectToAction("index", "Login");
            }

        }
        [HttpPost]
        public ActionResult Signup(UserRegistration form)
        {
            if (form.Password != form.ConfirmPassword)
            {
                ViewBag.msg = "Password does not match";
                return RedirectToAction("ownerSignup", "Login");
            }

            LogInInfo log = new LogInInfo
            {
                Username = form.Username,
                Password = form.Password,
                Type = 2,
                IsBlocked = 0
            };

            Owner usr = new Owner
            {
                Mobile = form.Mobile,
                Email = form.Email
            };

            OwnerService service = new OwnerService();

            if (service.register(log, usr))
               return RedirectToAction("index", "Login");
            else
            {

                ViewBag.msg2 = "Username Already Exists";
               return RedirectToAction("ownerSignup", "Login");
            }
            
        }
        public ActionResult CreateOffer(Offer aOffer)
        {
            OfferService service = new OfferService();
            service.createOffer(aOffer);
            return RedirectToAction("index","Owner");
        }
        public ActionResult CreatePromo(Promo aPromo)
        {
            OfferService service = new OfferService();
            service.createPromo(aPromo);
            return RedirectToAction("index", "Owner");
        }
        public ActionResult AcceptRequest(int id)
        {
            OwnerBookingManagementService service = new OwnerBookingManagementService();
            service.acceptRequest(id);
            return RedirectToAction("requests","Owner");
        }
        public ActionResult CancelRequest(int id)
        {
            OwnerBookingManagementService service = new OwnerBookingManagementService();
            service.cancelRequest(id);
            return RedirectToAction("requests", "Owner");
        }
    }
}