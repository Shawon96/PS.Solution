using PS.Core.Entities.Other;
using PS.Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PS.Web.Mvc.Models
{
    public class UserBookingModel
    {
        public int idBook { get; set; }

        
        public int PlaceId { get; set; }
        public string Name { get; set; }
        public double Price{ get; set; }
        public DateTime Date { get; set; }

        public int IsPending { get; set; }
    }
}