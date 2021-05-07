using System;
using RRModels;
using System.Collections.Generic;
using RRDL;
using RRBL;
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
            switch (menuType.ToLower())
            {
                case "main":
                    return new MainMenu();
                case "restaurant":
                    return new RestaurantMenu(deps, new ValidationService());
                default:
                    return null;
            }
        }
        
    }
}