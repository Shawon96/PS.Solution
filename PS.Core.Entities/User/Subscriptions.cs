using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PS.Core.Entities.User
{
    public class Subscriptions
	{
        public int ID  { get; set; }

        public int UserId  { get; set; }
        public int  PlaceId  { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime Date { get; set; }
        public int IsPending { get; set; }
    }
}