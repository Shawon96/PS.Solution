using PS.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.Core.Entities.Owner;
using PS.Infrastructure;
using PS.Core.Entities.Other;
using PS.Core.Entities.User;

namespace PS.Core.Service.Services
{
    public class PlaceService : IPlaceService
    {
        public bool approvePlace(int aPlaceId)
        {
            // Caution: Update May Not Work..
            PsDbContex db = new PsDbContex();

            ParkingPlace el = db.ParkingPlaces.SingleOrDefault(r => r.ID == aPlaceId);
            if (el == null) return false;

            el.IsBlocked = 0;
            db.SaveChanges();

            return true;
        }

        public int createPlace(ParkingPlace aParkingPlace)
        {
            PsDbContex db = new PsDbContex();
            var x = db.ParkingPlaces.Add(aParkingPlace);
            db.SaveChanges();

            return x.ID;
        }

        public bool deletePlace(int aPlaceId)
        {
            PsDbContex db = new PsDbContex();

            ParkingPlace el = db.ParkingPlaces.SingleOrDefault(r => r.ID == aPlaceId);
            if (el == null) return false;
            db.ParkingPlaces.Remove(el);
            db.SaveChanges();

            return true;
        }

        public int editPlace(ParkingPlace aParkingPlace, int aPlaceId)
        {
            // Caution: Update May Not Work..
            PsDbContex db = new PsDbContex();

            ParkingPlace el = db.ParkingPlaces.SingleOrDefault(r => r.ID == aParkingPlace.ID);
            if (el == null) return 0;
            el.SpotName = aParkingPlace.SpotName;
            el.SpotLocation = aParkingPlace.SpotLocation;
            el.PricePerHour = aParkingPlace.PricePerHour;
            el.Capacity = aParkingPlace.Capacity;
            db.SaveChanges();

            return 1;
        }

        public List<ParkingPlace> getAllPlaces()
        {
            PsDbContex db = new PsDbContex();
            List<ParkingPlace> data;

            try
            {
                var el = from r in db.ParkingPlaces select r;
                data = el.ToList();
            }
            catch
            {
                return null;
            }

            return data;
        }
        public List<ParkingPlace> getAllPlaces(int aOwnerId)
        {
            PsDbContex db = new PsDbContex();
            List<ParkingPlace> data;

            try
            {
                var el = from r in db.ParkingPlaces
                         where r.OwnerId == aOwnerId
                         select r;
                data = el.ToList();
            }
            catch
            {
                return null;
            }

            return data;
        }

        public List<ParkingPlace> getMatchedPlaces(string match)
        {
            PsDbContex db = new PsDbContex();
            List<ParkingPlace> data;

            try
            {
                var el = from r in db.ParkingPlaces
                         where r.SpotLocation.Contains(match) || r.SpotName.Contains(match)
                         select r;
                data = el.ToList();
            }
            catch
            {
                return null;
            }

            return data;

            /*List<ParkingPlace> data = new List<ParkingPlace>();
            ParkingPlace p1 = new ParkingPlace()
            {
                ID = 10,
                OwnerId = 15,
                PricePerHour = 5.0,
                SpotName = "SpotA"
            };
            ParkingPlace p2 = new ParkingPlace()
            {
                ID = 10,
                OwnerId = 15,
                PricePerHour = 5.0,
                SpotName = "SpotB"
            };
            ParkingPlace p3 = new ParkingPlace()
            {
                ID = 10,
                OwnerId = 15,
                PricePerHour = 5.0,
                SpotName = "SpotC"
            };

            data.Add(p1);
            data.Add(p2);
            data.Add(p3);
            return data;*/
        }

        public ParkingPlace getPlaceInfo(int id)
        {
            PsDbContex db = new PsDbContex();
            ParkingPlace el = new ParkingPlace() { SpotName = "DEBUG" };
            el = db.ParkingPlaces.SingleOrDefault(r => r.ID == id);
            //if (el == null) return el;
            return el;
        }

        public List<ParkingPlace> getPlaceInfo2(int id)
        {
            PsDbContex db = new PsDbContex();
            ParkingPlace el = db.ParkingPlaces.SingleOrDefault(r => r.ID == id);
            List<ParkingPlace> li = new List<ParkingPlace>();
            li.Add(el);
            if (el == null) return li;
            return li;
        }

        public int RequestPlace(Booking book)
        {

            PsDbContex db = new PsDbContex();
            var x = db.Bookings.Add(book);
            db.SaveChanges();

            return x.ID;
        }
        public int SubscribePlace(Subscriptions sub)
        {
            PsDbContex db = new PsDbContex();
            var x = db.Subscriptions.Add(sub);
            db.SaveChanges();

            return x.ID;
        }
    }
}
