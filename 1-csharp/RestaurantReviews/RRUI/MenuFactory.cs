using System.IO;
using System;
using RRModels;
using System.Collections.Generic;
using RRDL;
using RRBL;
using Microsoft.Extensions.Configuration;

namespace RRUI
{
    /// <summary>
    /// Class to "menu"-facture menus using factory dp
    /// </summary>
    public class MenuFactory
    {
        private static IRestaurantBL deps = new RestaurantBL(new RepoFile());
        public static IMenu GetMenu(string menuType)
        {
            //config from a config file
            var configuraion = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            //setting up my db connections
            string connectionString = configuraion.GetConnectionString("RestaurantDB");
            //we're building the dbcontext using the constructor that takes in options, we're setting the connection 
            //string outside the context definitions
            DbContextOptions<RestaurantDBContext> options = new DbContextOptionsBuilder<RestaurantDBContext>()
            .UseSqlServe(connectionString)
            .Options;
            //passing in the options we just built
            var context = new RestaurantDBContext(options);
            switch (menuType.ToLower())
            {
                case "main":
                    return new MainMenu();
                case "restaurant":
                    return new RestaurantMenu(deps, new ValidationService());
                case "review":
                    return new ReviewMenu(deps, new ValidationService());
                default:
                    return null;
            }
        }
        
    }
}