using System.Collections.Generic;
using RRModels;
namespace RRBL
{
    public interface IRestaurantBL
    {
        List<Restaurant> GetAllRestaurants();
        Restaurant AddRestaurant(Restaurant r);
        Restaurant GetRestaurant(Restaurant r);
    }
}