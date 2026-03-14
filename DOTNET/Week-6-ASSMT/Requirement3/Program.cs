using System;
using System.Text.RegularExpressions;

namespace Requirement3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the registration no. to be validated");
                string registrationNo = Console.ReadLine();
                bool valid = ValidateRegistrationNo(registrationNo);
                if (valid)
                {
                    Console.WriteLine("Registration No. is valid");
                }
                else
                {
                    Console.WriteLine("Registration No. is invalid");
                }
            }
            catch (Exception)
            {
                // Handles unexpected runtime errors
                Console.WriteLine("An unexpected error occurred");
            }
        }

        // Validates the registration number based on the given format rules
        static bool ValidateRegistrationNo(string registrationNo)
        {
            try
            {
                // Regex pattern as per the problem statement
                string pattern = @"^[A-Z]{2} [0-9]{1,2} [A-Z]{0,2} [0-9]{1,4}$";
                return Regex.IsMatch(registrationNo, pattern);
            }
            catch (ArgumentNullException)
            {
                // Handles null input
                return false;
            }
        }
    }
}
