using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Core.Entities.Other
{
    public class Request
    {
        public int ID { get; set; }

        public int UserId { get; set; }
        public int PlaceId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
