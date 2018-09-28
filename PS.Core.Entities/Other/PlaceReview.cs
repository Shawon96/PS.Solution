using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Core.Entities.Other
{
    public class PlaceReview
    {
        public int ID { get; set; }

        public DateTime Time { get; set; }
        public int CarUserId { get; set; }
        public int ToPlaceId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
