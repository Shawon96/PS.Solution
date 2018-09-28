using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PS.Web.Mvc.Models
{
    public class OwnerBookingModel
    {
        public int isBook { get; set; }
        public int BookId { get; set; }
        public string ParkerName { get; set; }
        public string PlaceName { get; set; }
        public DateTime Date { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int IsPending { get; set; }
    }
}