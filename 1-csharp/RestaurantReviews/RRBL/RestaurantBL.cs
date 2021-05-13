using System.Collections.Generic;
using RRDL;
using RRModels;
namespace RRBL
{
    /// <summary>
    /// Business logic for restaurant model / CRUD
    /// </summary>
    public class RestaurantBL : IRestaurantBL
    {
        /// <summary>
        /// BL Classes are in charge of processing/ sanitizing/ further validating data
        /// In charge of processing logic. how does trhe ordering process
        /// accessing data is relegated to the DL
        /// </summary>
        /// <returns></returns>
        private IRepository _repo;
        public RestaurantBL(IRepository repo){
            _repo = repo;
        }
        public List <Restaurant> GetAllRestaurants(){
            return _repo.GetAllRestaurants();
            //Note this method isn't really dependent on any parameters, just directly call DL method in charge
            //of getting the restaurants
        }
        public Restaurant AddRestaurant(Restaurant restaurant){
            if(_repo.GetRestaurant(restaurant) != null){
                throw new System.Exception("Restaurant already exists.");
            }
            return _repo.AddRestaurant(restaurant);
        }

        public Restaurant GetRestaurant(Restaurant r)
        {
            return _repo.GetRestaurant(r);
        }
    }
}