using RRModels;
using System.Collections.Generic;
using System;
namespace RRBL
{
    public interface IReviewBl
    {
        Review AddReview(Restaurant restaurant, Review review);
        Tuple<List<Review>,int> GetReviews(Restaurant restaurant);
    }
}