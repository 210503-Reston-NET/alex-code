using System;
using RRModels;
namespace RRUI
{
    public class program
    {
        static void Main(string[] args){
            Restaurant goodTaste =  new Restaurant("Good Taste", "Baguio City", "Benguet");
            goodTaste.Review = new Review{
                Rating = 5,
                Description = "Great"
            };
            Console.WriteLine(goodTaste.ToString());
        }
    }
}