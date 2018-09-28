using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Core.Entities.Other
{
   public class Booking
    {
        public int ID { get; set; }

        public int UserId { get; set; }
        public int PlaceId { get; set; }
        public string PromoCode { get; set; }

        public int IsPending { get; set; }
    }
}
