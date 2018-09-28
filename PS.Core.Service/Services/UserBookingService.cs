using PS.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.Core.Entities.Other;
using PS.Core.Entities.User;
using PS.Infrastructure;

namespace PS.Core.Service.Services
{
    public class UserBookingService : IUserBookingService
    {
        //pending = 0  and  active = 1
        public List<Booking> getAllBookings(int aUserId)
        {
            //getAllRequests()

            PsDbContex db = new PsDbContex();
            List<Booking> data= new List<Booking>();

            try
            {
                var el = from r in db.Bookings
                         where r.UserId == aUserId
                         select r;
                data = el.ToList();
            }
            catch
            {
                return null;
            }

            return data;
        }

        public List<Subscriptions> GetAllSubscriptions(int aUserId)
        {
            PsDbContex db = new PsDbContex();
            List<Subscriptions> data;

            try
            {
                var el = from r in db.Subscriptions
                         where r.UserId == aUserId
                         select r;
                data = el.ToList();
            }
            catch
            {
                return null;
            }

            return data;
        }
        public bool bookPlace(Booking aBooking, int aUserId)
        {
            aBooking.UserId = aUserId;
            aBooking.IsPending = 0;

            PsDbContex db = new PsDbContex();
            db.Bookings.Add(aBooking);
            db.SaveChanges();

            return true;
        }

        public Booking getBookInfo(int id)
        {
            PsDbContex db = new PsDbContex();
            Booking el = db.Bookings.SingleOrDefault(r => r.ID == id);
            if (el == null) return el;
            return el;
        }
        public Subscriptions getSubInfo(int id)
        {
            PsDbContex db = new PsDbContex();
            Subscriptions el = db.Subscriptions.SingleOrDefault(r => r.ID == id);
            if (el == null) return el;
            return el;
        }
    }
}
