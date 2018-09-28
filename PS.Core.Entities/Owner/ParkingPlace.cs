using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Core.Entities.Owner
{
    public class ParkingPlace
    {
        public int ID { get; set; }

        public int OwnerId { get; set; }
        public string SpotName { get; set; }
        public string SpotLocation { get; set; }
        public double PricePerHour { get; set; }
        public int Capacity { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        //public int Rating { get; set; }
        public int IsBlocked { get; set; }
    }
}
