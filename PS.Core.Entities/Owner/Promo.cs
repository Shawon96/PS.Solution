using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PS.Core.Entities.Owner
{
    public class Promo
    {
        public int ID { get; set; }

        public int PlaceId { get; set; }
        public string PromoCode { get; set; }
        public float DiscountRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}