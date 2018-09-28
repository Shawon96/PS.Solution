using PS.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.Core.Entities.Owner;
using PS.Infrastructure;

namespace PS.Core.Service.Services
{
    public class FacilityService : IFacilityService
    {
        public List<Facility> getAllFacilities(int aOwnerId)
        {
            PsDbContex db = new PsDbContex();
            List<Facility> data;

            try
            {
                var el  = from r in db.Facilities
                          where r.OwnerId == aOwnerId
                          select r;
                data = el.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

            return data;
        }

        public List<Facility> getAllFacilitiesWithPlaceId(int aOwnerId, int aPlaceId)
        {
            PsDbContex db = new PsDbContex();
            List<Facility> data;

            try
            {
                var el = from r in db.Facilities
                         where r.OwnerId == aOwnerId && r.Popularity == aPlaceId
                         select r;
                data = el.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

            return data;
        }

        public int setNewFacilty(Facility aFacility)
        {
            PsDbContex db = new PsDbContex();
            var x = db.Facilities.Add(aFacility);
            db.SaveChanges();

            return x.ID;
        }

        public string getFacility(int placeId)
        {
            PsDbContex db = new PsDbContex();
            List<Facility> data = new List<Facility>();

            var el = from r in db.Facilities
                     where r.Popularity == placeId
                     select r;
            data = el.ToList();

            if (data.Count == 0) return "N/A";
            else
            {
                string str = "\n";
                for (int i=0; i<data.Count; i++)
                {
                    str += data[i].Description;
                }
                return str;
            }
        }
    }
}
