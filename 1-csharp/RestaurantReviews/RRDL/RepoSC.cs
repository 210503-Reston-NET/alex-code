using System.Collections.Generic;
using RRModels;
using System.Linq;
namespace RRDL
{
    //implementation of IRepository that stores data in a static collection
    public class RepoSC : IRepository 
    {
        public List<Restaurant> GetAllRestaurants(){
            return RRSCStorage.Restaurants;
        }
        public Restaurant AddRestaurant(Restaurant r){
            RRSCStorage.Restaurants.Add(r);
            return r;
        }
        public Restaurant GetRestaurant(Restaurant r)
        {
            /// <summary>
            /// Uses Linq, which allows you to query collections to get the necessary data
            /// w/o having to traverse collection manually in a foreach iteration
            /// </summary>
            /// <returns></returns>
            return RRSCStorage.Restaurants.FirstOrDefault(resto => resto.Equals(r));

        }
    }
}