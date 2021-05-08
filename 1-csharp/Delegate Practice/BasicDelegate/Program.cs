using System;

namespace BasicDelegate
{
    /*class Program
    {
        public delegate void ExampleDelegate<in Parent>(Parent p);
        static void Main(string[] args)
        {
            ExampleDelegate del = BasicCount;
            del += BasicDec;
            NewCounter(new Child(), del);
        }
        public static BasicCount(Child i){
            //i +=1;
            Console.WriteLine("This is your number: " + i.ToString());
        } 
        public static void NewCounter(Child j, ExampleDelegate del){
            del(j);
        }
        public static void BasicDec(Child i){
            //i -=1;
            Console.WriteLine("This is your new number: " + i.ToString());
        }
    }
}*/
class Mammals {}  
class Dogs : Mammals {}  
  
class Program  
{  
    // Define the delegate.  
    public delegate Mammals HandlerMethod(Dogs d);  
  
    public static Mammals MammalsHandler(Mammals m)  
    {  
        return null;  
    }  
  
    public static Dogs DogsHandler()  
    {  
        return null;  
    }  
  
    static void Test()  
    {  
        HandlerMethod handlerMammals = MammalsHandler;  
  
        // Covariance enables this assignment.  
        //HandlerMethod handlerDogs = DogsHandler;  
    }  
} } 