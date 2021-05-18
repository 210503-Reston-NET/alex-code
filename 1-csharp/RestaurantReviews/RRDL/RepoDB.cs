using System.Collections.Generic;
using RRModels;
using Entity = RRDL.Entities;
using Model = RRModels.Models;
using System.Linq;
namespace RRDL
{
    public class RepoDB : IRepository
    {
        
        public Model.Restaurant AddRestaurant(Model.Restaurant r)
        {
            //records a change in context change tracker that we want to add to the DB
            _context.Restaurants.Add(
                new Entity.Restaurant{
                    Name = r.Name,
                    City = r.City,
                    State = r.State
            });
            //Persists the change to the db
            //Note: you can create a seperate method that persists changes so you can execute repo commands in the business logic
            //and only save changes when all operations return no exceptions
            _context.SaveChanges();
            return r;
        }

        public Restaurant AddRestaurant(Restaurant r)
        {
            throw new System.NotImplementedException();
        }

        public Model.Review AddReview(Restaurant r, Review review)
        {
            Entity.Restaurant found = _context.Restaurants.Include("Reviews").FirstOrDefault(resto => resto.Name == r.Name && resto.City = r.City && resto.State = r.State));
            found.Reviews.Add(
                new Entity.Review{
                    Rating = review.Rating,
                    Description = review.Description
                }
                );
            _context.SaveChanges();
            return review;
            
        }

        public Restaurant DeleteRestaurant(Restaurant restaurant)
        {
            return _context.Restuarants.Where(resto => resto.Id == restaurant.Id).Remove(restaurant.Id);
        }

        public List<Model.Restaurant> GetAllRestaurants()
        {
            return _context.Restaurants.Select<Model.Restaurant>(restaurant => (
                new Model.Restaurant(restaurant.Name,restaurant.City, restaurant.State)
            )).ToList();
        }

        public Model.Restaurant GetRestaurant(Restaurant r)
        {
            //find restaurant that is equal to input resaurant
            Entity.Restaurant found = _context.Restaurants.FirstOrDefault(resto => resto.Name == r.Name && resto.City = r.City && resto.State = r.State);
            //return found restaurant or null if it isn't in db
            if(found == null) return null;
            return new Model.Restaurant(found.Id,found.Name, found.City, found.State);
        }

        public List<Review> GetReviews(Restaurant r)
        {
            //get reviews such that, we find the restaurant that matches the restaurant being passed,
            //we get the id of that specific restaurant, compare it to FK references in the Reviews table
            //get the reviews that match the condition
            //transform entity type reviews into a model type review
            //immediately execute the query by calling toList which takes the data from db and puts it in list

            //find restaurant from the db, to be able to take advantage of id property
            //Entity.Restaurant foundResto = _context.Restaurants.FirstOrDefault(resto => resto.Name == r.Name && resto.City = r.City && resto.State = r.State);
            return _context.Reviews.Where(review => review.RestaurantId ==
                review => Review.RestaurantId == GetRestaurant(r).Id//_context.Restaurants.FirstOrDefault(resto => resto.Name == r.Name && resto.City = r.City && resto.State = r.State
                ).Select(
                    review => new Model.Review{
                        Rating = review.Rating,
                        Description = review.Description
                    }
                )
            ).ToList();
        }

        Review IRepository.AddReview(Restaurant restaurant, Review review)
        {
            throw new System.NotImplementedException();
        }

        List<Restaurant> IRepository.GetAllRestaurants()
        {
            throw new System.NotImplementedException();
        }

        Restaurant IRepository.GetRestaurant(Restaurant r)
        {
            throw new System.NotImplementedException();
        }
    }
}