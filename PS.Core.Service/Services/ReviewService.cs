using PS.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.Core.Entities.Other;
using PS.Infrastructure;

namespace PS.Core.Service.Services
{
    public class ReviewService : IReviewService
    {
        public bool createReview(Review aReview)
        {
            aReview.Time = DateTime.Today;
            PsDbContex db = new PsDbContex();
            db.Reviews.Add(aReview);
            db.SaveChanges();

            return true;
        }

        public int createPlaceReview(PlaceReview rev)
        {
            rev.Time = DateTime.Today;

            PsDbContex db = new PsDbContex();
            var x = db.PlaceReviews.Add(rev);
            db.SaveChanges();

            return x.ID;
        }

        public List<Review> getAllGivenReviews(int personId)
        {
            PsDbContex db = new PsDbContex();
            List<Review> data;

            try
            {
                var el = from r in db.Reviews
                         where r.FromUserId == personId
                         select r;
                data = el.ToList();
            }
            catch
            {
                return null;
            }

            return data;
        }
        public List<Review> getAllReviews(int personId)
        {
            PsDbContex db = new PsDbContex();
            List<Review> data;

            try
            {
                var el = from r in db.Reviews
                         where r.ToUserId == personId || r.FromUserId == personId
                         select r;
                data = el.ToList();
            }
            catch
            {
                return null;
            }

            return data;
        }
        public List<PlaceReview> getAllPlaceReviews(int personId)
        {
            PsDbContex db = new PsDbContex();
            List<PlaceReview> data;

            try
            {
                var el = from r in db.PlaceReviews
                         where r.CarUserId == personId
                         select r;
                data = el.ToList();
            }
            catch
            {
                return null;
            }

            return data;
        }

        public List<Review> getAllReceivedReviews(int personId)
        {
            PsDbContex db = new PsDbContex();
            List<Review> data;

            try
            {
                var el = from r in db.Reviews
                         where r.ToUserId == personId
                         select r;
                data = el.ToList();
            }
            catch
            {
                return null;
            }

            return data;
        }

        public double getRating(int pId)
        {
            PsDbContex db = new PsDbContex();
            List<PlaceReview> ls = new List<PlaceReview>();
            var el = from r in db.PlaceReviews
                          where r.ToPlaceId == pId
                          select r;
            ls = el.ToList();

            if (ls.Count == 0) return 0.0;

            var d = db.PlaceReviews.Where(r => r.ToPlaceId == pId).Average(r => r.Rating);
            string rat = d.ToString(); 
            return Convert.ToDouble(rat);
        }
    }
}
