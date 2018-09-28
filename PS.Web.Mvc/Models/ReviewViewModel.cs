using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PS.Web.Mvc.Models
{
    public class ReviewViewModel
    {
        public DateTime Time { get; set; }
        public int IsToMe { get; set; }
        public string Who { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}