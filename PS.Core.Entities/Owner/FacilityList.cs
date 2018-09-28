using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Core.Entities.Owner
{
    public class FacilityList
    {
        public int ID { get; set; }

        public int OwnerId { get; set; }
        public int FacilityId { get; set; }

    }
}
