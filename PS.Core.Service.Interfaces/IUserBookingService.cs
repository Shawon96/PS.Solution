using PS.Core.Entities.Other;
using PS.Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Core.Service.Interface
{
    public interface IUserBookingService
    {
        bool bookPlace(Booking aBooking, int aUserId);
        List<Booking> getAllBookings(int aUserId);
        List<Subscriptions> GetAllSubscriptions(int aUserId);
    }
}
