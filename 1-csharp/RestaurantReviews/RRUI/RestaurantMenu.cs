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
    private void ViewRestaurant(){
           
            List<Restaurant> restaurants = _restaurantBL.GetAllRestaurants();
            foreach(Restaurant r in restaurants){
                
                Console.WriteLine(r.ToString());
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

        Restaurant newRestaurant = new Restaurant(name, city, state);
        try{
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