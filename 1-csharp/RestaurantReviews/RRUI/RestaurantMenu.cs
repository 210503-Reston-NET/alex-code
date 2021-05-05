using System;
using RRModels;
using System.Collections.Generic;
using RRBL;
namespace RRUI
{
    public class RestaurantMenu : IMenu
    {
        private IRestaurantBL _restaurantBL;
        public RestaurantMenu( IRestaurantBL restaurantBL){
            this._restaurantBL = restaurantBL;
        }
        public void Start(){
            bool repeat = true;
            do
            {
                Console.WriteLine("Welcome to my Restaurant Review App!");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[0] View Restaurant");
                Console.WriteLine("[1] Exit");
                string input = Console.ReadLine();
                
                switch(input){
                    case "0":
                        //view a restaurant
                        ViewRestaurant();
                        break;
                    case "1":
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
}
}