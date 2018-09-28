using PS.Core.Entities.Owner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Core.Service.Interface
{
    public interface IFacilityService
    {
        List<Facility> getAllFacilities( int aOwnerId);
        List<Facility> getAllFacilitiesWithPlaceId(int aOwnerId, int aPlaceId);
        int setNewFacilty(Facility aFacility);
    }
}
