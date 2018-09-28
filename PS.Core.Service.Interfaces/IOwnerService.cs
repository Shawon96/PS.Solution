using PS.Core.Entities.Other;
using PS.Core.Entities.Owner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Core.Service.Interface
{
    public interface IOwnerService
    {
        IEnumerable<Owner> getOwners();
        bool register(LogInInfo log, Owner aOwner);
        bool blockOwner(int ownerId);
        bool approveOwner(int ownerId);
    }
}
