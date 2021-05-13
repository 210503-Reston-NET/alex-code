using System;
using System.Collections.Generic;
using RRBL;
using RRDL;
using RRModels;

namespace RRUI
{
    public class ReviewMenu : IMenu
    {
        private IRestaurantBL _restaurantBL;
        private IValidationService _validate;
        private IReviewBl _reviewBl = new ReviewBL(new RepoDB());
        public ReviewMenu(IRestaurantBL restaurantBL, IValidationService validation){
            _restaurantBL = restaurantBL;
            _validate = validation;
        }
        public void Start()
        {
            bool repeat = true;
            Restaurant reviewable = SearchForRestaurant();
            if(reviewable != null){
                do{
                Console.WriteLine($"Welcome to the Reviews Menu of {reviewable.Name}! What would you like to do?");
                Console.WriteLine("[0] Add a review");
                Console.WriteLine("[1] View reviews");
                Console.WriteLine("[1] Go back");
                string input = Console.ReadLine();
                switch(input){
                    case "0":
                    //Add review method
                        AddReview(reviewable);
                        break;
                    case "1":
                        ViewReview(reviewable);
                        break;
                    case "2":
                        repeat = false;
                        Console.WriteLine("Back to restaurants");
                        break;
                    default:
                        Console.WriteLine("Sorry, invalid input");
                        break;
                }
            }
                }while(repeat);
                
        }

        private void ViewReview(Restaurant reviewable)
        {
            Console.WriteLine($"Here are the reviews for the restaurant {reviewable.Name}");
            Tuple<List<Review>,int> reviewResult = _reviewBL.GetReviews(reviewable);
            reviewResult.Item1.ForEach(review => Console.WriteLine(review.ToString()));
            Console.WriteLine($"Here's the average {reviewResult.Item2}");
        }

        private void AddReview(Restaurant reviewable)
        {
            int _rating = _validate.ValidateInt("Enter the rating you'd give this restaurant");
            string description = _validate.ValidateString("Like speak your mind.....");
            //call BL method that attempts to add a review to a restaurant 
        }

        private Restaurant SearchForRestaurant()
        {
            Console.WriteLine("Enter the restaurant details of the restaurant you're looking for. Case sensitive");
            //Want to make sure end user doesn't just input nothing
            //Validate input that you're receiving.
            //Set model specification rules within the properties of your models
            //But have standard validation
            string name = _validate.ValidateString("Enter the restaurant name");
            string city = _validate.ValidateString("Enter the restaurant's city");
            string state = _validate.ValidateString("Enter the state of the restaurant");

            try{
                Restaurant newRestaurant = new Restaurant(name, city, state);
                Restaurant foundRestaurant = _restaurantBL.GetRestaurant(newRestaurant);
                Console.WriteLine("Restaurant found");
                return foundRestaurant;
            }
            catch(Exception ex){
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}