using PS.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.Core.Entities.Other;
using PS.Infrastructure;
using PS.Core.Entities.Owner;
using PS.Core.Entities.User;

namespace PS.Core.Service.Services
{
    public class OwnerBookingManagementService : IOwnerBookingManagementService
    {
        //pending = 0  and  active = 1
        public bool acceptRequest(int aRequestId)
        {
            // Caution: Update May Not Work..
            PsDbContex db = new PsDbContex();
            List<Booking> data;

            try
            {
                var el = from r in db.Bookings
                         where r.ID == aRequestId
                         select r;
                data = el.ToList();
            }
            catch
            {
                return false;
            }

            if (data.Count != 1) return false;
            data[0].IsPending = 0;
            db.SaveChanges();

            return true;
        }

        public bool cancelRequest(int aRequestId)
        {
            PsDbContex db = new PsDbContex();
            List<Booking> data;

            try
            {
                var el = from r in db.Bookings
                         where r.ID == aRequestId
                         select r;
                data = el.ToList();

                if (data.Count != 1) return false;
                db.Bookings.Remove(data[0]);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Booking> getAllBookings(int aOwnerId)
        {
            PsDbContex db = new PsDbContex();
            List<ParkingPlace> placeData;

            try
            {
                var el = from r in db.ParkingPlaces
                         where r.OwnerId == aOwnerId
                         select r;
                placeData = el.ToList();
            }
            catch
            {
                return null;
            }

            /**********************************************************************/

            List<Booking> data = new List<Booking>();

            for (int i=0; i<placeData.Count; i++)
            {
                int placeId = placeData[i].ID;

                Booking el = db.Bookings.SingleOrDefault(r => r.PlaceId == placeId);
                if(el != null) data.Add(el);
            }

            return data;
        }
        public List<Subscriptions> getAllSubscriptions(int aOwnerId)
        {
            PsDbContex db = new PsDbContex();
            List<ParkingPlace> placeData;

            try
            {
                var el = from r in db.ParkingPlaces
                         where r.OwnerId == aOwnerId
                         select r;
                placeData = el.ToList();
            }
            catch
            {
                return null;
            }

            /**********************************************************************/

            List<Subscriptions> data = new List<Subscriptions>();

            for (int i = 0; i < placeData.Count; i++)
            {
                int placeId = placeData[i].ID;

                Subscriptions el = db.Subscriptions.SingleOrDefault(r => r.PlaceId == placeId);
                if (el != null) data.Add(el);
            }

            return data;
        }

        public List<Booking> getAllRequests(int aOwnerId)
        {
            PsDbContex db = new PsDbContex();
            List<ParkingPlace> placeData;

            try
            {
                var el = from r in db.ParkingPlaces
                         where r.OwnerId == aOwnerId
                         select r;
                placeData = el.ToList();
            }
            catch
            {
                return null;
            }

            /**********************************************************************/

            List<Booking> data = new List<Booking>();

            for (int i = 0; i < placeData.Count; i++)
            {
                int placeId = placeData[i].ID;

                Booking el = db.Bookings.SingleOrDefault(r => r.PlaceId == placeId && r.IsPending == 0);
                if (el != null) data.Add(el);
            }

            return data;
        }

    }
}
