using PS.Core.Entities.Owner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Core.Service.Interface
{
   public  interface IOfferService
    {
        bool createOffer(Offer aOffer);
        bool createPromo(Promo aPromo);
    }
}
