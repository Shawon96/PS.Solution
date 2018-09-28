using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PS.Core.Entities.Owner
{
    public class Offer
    {
        public int ID { get; set; }

        public int PlaceId { get; set; }
        public double ParkingRate { get; set; }
        public double FixDiscount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
        
    }
}