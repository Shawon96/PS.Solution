using PS.Core.Entities.Owner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Core.Service.Interface
{
    public interface IPlaceService
    {
        int editPlace(ParkingPlace aParkingPlace, int aPlaceId);
        int createPlace(ParkingPlace aParkingPlace);
        List<ParkingPlace> getAllPlaces(int aOwnerId);
        bool approvePlace(int placeId);
        bool deletePlace(int aPlaceId);
    }
}
