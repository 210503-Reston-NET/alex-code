using System;
namespace RRUI
{
    public class ValidationService : IValidationService
    {
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