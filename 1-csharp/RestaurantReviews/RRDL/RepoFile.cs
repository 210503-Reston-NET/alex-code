using System.Collections.Generic;
using RRModels;
using System.IO;
using System.Text.Json;
using System;
using System.Linq;
namespace RRDL
{
    /// <summary>
    /// Repo implementation but stores it in a file
    /// </summary>
    public class RepoFile : IRepository
    {
        //file path relative to where you run the dotnet run command
        //We run it in RRUI, filepath is relative to how you navigate to the file
        private const string filePath = "../RRDL/Restaurants.json";
        private string jsonString;
        public List<Restaurant> GetAllRestaurants(){
        try{
            jsonString = File.ReadAllText(filePath);
        } catch (Exception){
            return new List<Restaurant>();
        }
            return JsonSerializer.Deserialize<List<Restaurant>>(jsonString);
        }
        public Restaurant AddRestaurant(Restaurant r){
            List<Restaurant> restaurantsFromFile = GetAllRestaurants();
            restaurantsFromFile.Add(r);
            jsonString = JsonSerializer.Serialize(restaurantsFromFile);
            File.WriteAllText(filePath, jsonString);
            return r;
        }
        public Restaurant GetRestaurant(Restaurant r)
        {
           return GetAllRestaurants().FirstOrDefault(resto => resto.Equals(r));
        }
    }
}