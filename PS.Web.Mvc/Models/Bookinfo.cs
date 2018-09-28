using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PS.Web.Mvc.Models
{
    public class Bookinfo
    {
        public int PlaceId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int IsPending { get; set; }
    }
}