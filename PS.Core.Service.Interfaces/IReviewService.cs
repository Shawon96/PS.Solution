using PS.Core.Entities.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Core.Service.Interface
{
    public interface IReviewService
    {
        bool createReview(Review aReview);
        List<Review> getAllGivenReviews(int personId);
        List<Review> getAllReceivedReviews(int personId);
    }
}
