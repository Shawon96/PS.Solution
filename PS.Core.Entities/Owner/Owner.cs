using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PS.Core.Entities.Owner
{
    public class Owner
	{
        public int ID { get; set; }

        public int OwnerId { get; set; }
        public string Mobile { set; get; }
        public string Email { set; get; }
    }
}