using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PS.Core.Entities.Other
{
    public class LogInInfo
    {
        public int ID { get; set; }

        public string Username { set; get; }
        public string Password { set; get; }
        public int Type { get; set; }
        public int IsBlocked { get; set; }
    }
}