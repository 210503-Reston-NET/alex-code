using System;
using RRModels;
using System.Collections.Generic;
namespace RRUI
{
    public class MainMenu : IMenu
    {
        public void Start(){
            bool repeat = true;
            do{
                Console.WriteLine("Welcome to my Restaurant Review App!");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[0] View a restaurant");
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
            } while(repeat);
        }
        private void ViewRestaurant(){
            //TODO: Remove hard-coded restaurant and refer to one that exists
            Restaurant goodTaste =  new Restaurant("Good Taste", "Baguio City", "Benguet");
            goodTaste.Reviews = new List<Review>{
                new Review{
                    Rating = 5,
                    Description = "Great"
                }, 
                new Review{
                    Rating = 5,
                    Description = "Good food for the taste."
                }
            };
            Console.WriteLine(goodTaste.ToString());
            foreach (Review review in goodTaste.Reviews){
                Console.WriteLine(review.ToString());
            }
        }
    }
}