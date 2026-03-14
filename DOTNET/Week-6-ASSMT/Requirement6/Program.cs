using System;
using System.Collections.Generic;

namespace Requirement6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Vehicle> listVehicles = new List<Vehicle>();
                Console.WriteLine("Enter number of vehicles");
                int noOfVehicles = int.Parse(Console.ReadLine());
                // Read vehicle details and create Vehicle objects
                for (int i = 0; i < noOfVehicles; i++)
                {
                    string input = Console.ReadLine();
                    Vehicle vh = Vehicle.CreateVehicle(input);
                    listVehicles.Add(vh);
                }
                // Get type-wise count
                SortedDictionary<string, int> sortedDict =Vehicle.TypeWiseCount(listVehicles);
                Console.Write("{0,-15} {1}\n", "Type", "No. of Vehicles");
                // Display type-wise count
                foreach (var item in sortedDict)
                {
                    Console.WriteLine("{0,-15} {1}", item.Key, item.Value);
                }
            }
            catch (FormatException)
            {
                // Handles invalid numeric input
                Console.WriteLine("Invalid input format");
            }
            catch (Exception)
            {
                // Handles unexpected runtime errors
                Console.WriteLine("An unexpected error occurred");
            }
        }
    }
}
