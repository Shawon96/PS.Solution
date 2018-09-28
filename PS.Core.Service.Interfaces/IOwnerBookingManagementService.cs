using PS.Core.Entities.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Core.Service.Interface
{
    public  interface IOwnerBookingManagementService
    {
        List<Booking> getAllRequests(int aOwnerId);
        List<Booking> getAllBookings(int aOwnerId);
        bool acceptRequest(int aRequestId);
        bool cancelRequest(int aRequestId);
    }
}
