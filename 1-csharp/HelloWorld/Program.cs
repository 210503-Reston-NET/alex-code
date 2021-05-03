using System;

namespace HelloWorld
{
    //this is by default called program, starting point of application
    //contains the main method
    class Program
    {
        // is the main method, first method that gets called. The compiler
        //looks for this method when you run thr program
        //1. Static - don't have to instantiate the program to call method
        //2. void - doesn't return anything, no results expected
        //3. takes in string[] args
        static void Main(string[] args)
        {
            //to run youir console app, run dotnet run on the folder that contains 
            //the .NET project.
            //dotnet build, makes sure code compiles
            //dotnet run, builds and runs the code
            Console.WriteLine("Hello World!");
        }
    }
}
