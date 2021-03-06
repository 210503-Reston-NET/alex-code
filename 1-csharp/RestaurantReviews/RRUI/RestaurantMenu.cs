using System;
using RRModels;
using System.Collections.Generic;
using RRBL;
namespace RRUI
{
    public class RestaurantMenu : IMenu
    {
        private IRestaurantBL _restaurantBL;
        private ValidationService _validate;
        public RestaurantMenu( IRestaurantBL restaurantBL, ValidationService validate){
            this._restaurantBL = restaurantBL;
            this._validate = validate;
        }
        public void Start(){
            bool repeat = true;
            do
            {
                Console.WriteLine("Welcome to my Restaurant Review App!");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[0] View Restaurant");
                Console.WriteLine("[1] Add Restaurant");
                Console.WriteLine("[2] Search restaurant");
                Console.WriteLine("[2] Exit");
                string input = Console.ReadLine();
                
                switch(input){
                    case "0":
                        //view a restaurant
                        ViewRestaurant();
                        break;
                    case "1":
                        //view a restaurant
                        AddARestaurant();
                        break;
                    case "2":
                        //SearchForRestaurant();
                        break;
                    case "3":
                        DeleteARestaurant();
                        break();
                    case "4":
                        //exit
                        Console.WriteLine("bye, bye");
                        repeat = false;
                        break;
                    default:
                        //invalid input
                        Console.WriteLine("please input a valid option");
                        break;
                }
            }while(repeat);
    }

        private void DeleteARestaurant()
        {
            Console.WriteLine("Enter the restaurant details of restaurant you want to delete");
            string name = _validate.ValidateString("Enter the restaurant name");
            string city = _validate.ValidateString("Enter the restaurant's city");
            string state = _validate.ValidateString("Enter the state of the restaurant");

            try{
                Restaurant newRestaurant = new Restaurant(name, city, state);
                Restaurant createdRestaurant = _restaurantBL.AddRestaurant(newRestaurant);
                Console.WriteLine("New Restaurant Created: ");
                Console.WriteLine(createdRestaurant.ToString());
            }
            catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
        }

        private void ViewRestaurant(){
           
            List<Restaurant> restaurants = _restaurantBL.GetAllRestaurants();
            //TODO look at marielle code
            if (restaurants.Count == 0) Console.WriteLine("No restaurants! Please add some!");
            else{
                foreach(Restaurant r in restaurants){
                
                    Console.WriteLine(r.ToString());
                }
            }

        }
    private void AddARestaurant()
    {
        Console.WriteLine("Enter the details of the new restaurant");
        //Want to make sure end user doesn't just input nothing
        //Validate input that you're receiving.
        //Set model specification rules within the properties of your models
        //But have standard validation
        string name = _validate.ValidateString("Enter the restaurant name");
        string city = _validate.ValidateString("Enter the restaurant's city");
        string state = _validate.ValidateString("Enter the state of the restaurant");

        try{
            Restaurant newRestaurant = new Restaurant(name, city, state);
            Restaurant createdRestaurant = _restaurantBL.AddRestaurant(newRestaurant);
            Console.WriteLine("New Restaurant Created: ");
            Console.WriteLine(createdRestaurant.ToString());
        }
        catch(Exception ex){
            Console.WriteLine(ex.Message);
        }
    }
}
}