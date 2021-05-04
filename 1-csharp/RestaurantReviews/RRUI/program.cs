using System;
using RRModels;
using System.Collections.Generic;
namespace RRUI
{
    public class program
    {
        static void Main(string[] args){
            //Setting a parent type to instance of a subtype is called covariance
            IMenu menu = new MainMenu();
            menu.Start();
        }
    }
}