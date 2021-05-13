using System;
namespace RRUI
{
    //generic validation service that validates general input/ put specific validation in models properties
    public class ValidationService : IValidationService
    {
        public int ValidateInt(string prompt)
        {
            bool repeat = true;
            int response;
            do{
                Console.WriteLine(prompt);
                try{
                    response = Int32.Parse(Console.ReadLine());
                    if(response>-1){
                        repeat = false;
                    } else
                    {
                        Console.WriteLine("Has to be non-negative");
                    }
                }catch(Exception){
                    Console.WriteLine("Invalid input. Enter valid integer");
                }
                
            }while(repeat);
        }

        public string ValidateString(string prompt){
            string response;
            bool repeat;
            do
            {
                Console.WriteLine(prompt);
                response = Console.ReadLine();
                repeat = string.IsNullOrWhiteSpace(response);
                if(repeat)
                    Console.WriteLine("Please input a valid string");
            }while (repeat);
            return response;
        }
    }
}