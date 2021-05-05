using System.Collections.Generic;
using RRModels;
namespace RRDL
{
    //implementation of IRepository that stores data in a static collection
    public class RepoSC : IRepository 
    {
        public List<Restaurant> GetAllRestaurants(){
            return RRSCStorage.Restaurants;
        }
    }
}