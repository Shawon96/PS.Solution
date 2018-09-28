using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PS.Web.Mvc.Models
{
    public class PlaceInfo
    {

        public string SpotName { get; set; }
        public string SpotLocation { get; set; }
        public double PricePerHour { get; set; }
        public int Capacity { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        //option
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string NewFacility { get; set; }

  
    }
}