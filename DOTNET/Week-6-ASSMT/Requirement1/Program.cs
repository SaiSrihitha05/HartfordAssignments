using System;

namespace Requirement1
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter Vehicle 1 Details");
                string[] input1 = Console.ReadLine().Split(',');

                Ticket ticket1 = new Ticket(input1[4],DateTime.Parse(input1[5]),double.Parse(input1[6]));

                Vehicle veh1 = new Vehicle(input1[0],input1[1],input1[2],double.Parse(input1[3]),ticket1);

                Console.WriteLine("Enter Vehicle 2 Details");
                string[] input2 = Console.ReadLine().Split(',');

                Ticket ticket2 = new Ticket(input2[4],DateTime.Parse(input2[5]),double.Parse(input2[6]));

                Vehicle veh2 = new Vehicle(input2[0],input2[1],input2[2],double.Parse(input2[3]),ticket2);

                // Empty line as per requirement
                Console.WriteLine();

                Console.WriteLine("Vehicle 1 Details:");
                Console.WriteLine("------------------");
                Console.WriteLine(veh1.ToString());

                Console.WriteLine();

                Console.WriteLine("Vehicle 2 Details:");
                Console.WriteLine("------------------");
                Console.WriteLine(veh2.ToString());

                if (veh1.Equals(veh2))
                {
                    Console.WriteLine("\nVehicle 1 is same as Vehicle 2");
                }
                else
                {
                    Console.WriteLine("\nVehicle 1 and Vehicle 2 are different");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid number or date format");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Error: Missing input values");
            }
            catch (Exception)
            {
                // fallback for unexpected issues
                Console.WriteLine("Error: Unexpected error occurred");
            }
        }
    }
}
