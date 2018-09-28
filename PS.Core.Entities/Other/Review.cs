using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PS.Core.Entities.Other
{
    public class Review
    {
        public int ID{ get; set; }

        public DateTime Time { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}