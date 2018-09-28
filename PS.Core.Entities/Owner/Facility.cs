using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Core.Entities.Owner
{
    public  class Facility
    {
        public int ID { get; set; }

        public int OwnerId { get; set; }
        public string Description { get; set; }
        public int Popularity { get; set; }
    }
}
