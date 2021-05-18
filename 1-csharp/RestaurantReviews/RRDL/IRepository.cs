using System.Collections.Generic;
using RRModels;
namespace RRDL
{
    public interface IRepository
    {
        List<Restaurant> GetAllRestaurants();
        Restaurant AddRestaurant(Restaurant r);
        Restaurant GetRestaurant(Restaurant r);
        Review AddReview(Restaurant restaurant, Review review);
        List<Review> GetReviews(Restaurant restaurant);

        Restaurant DeleteRestaurant(Restaurant restaurant);
    }
}