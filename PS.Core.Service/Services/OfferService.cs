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
    public class OfferService : IOfferService
    {
        public bool createOffer(Offer aOffer)
        {
            PsDbContex db = new PsDbContex();
            db.Offers.Add(aOffer);
            db.SaveChanges();

            return true;
        }

        public bool createPromo(Promo aPromo)
        {
            PsDbContex db = new PsDbContex();
       

            db.Promos.Add(aPromo);
            db.SaveChanges();

            return true;
        }
    }
}
