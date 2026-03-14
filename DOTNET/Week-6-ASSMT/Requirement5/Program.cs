using System;
using System.Collections.Generic;

namespace Requirement5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> listVehicles = new List<Vehicle>();

            try
            {
                Console.WriteLine("Enter number of vehicles");
                int noOfVehicles = int.Parse(Console.ReadLine());
                // Read vehicle details and create Vehicle objects
                for (int i = 0; i < noOfVehicles; i++)
                {
                    string input = Console.ReadLine();
                    Vehicle vh = Vehicle.CreateVehicle(input);
                    listVehicles.Add(vh);
                }
                bool flag = true;
                while (flag)
                {
                    Console.WriteLine("Enter a type to sort:");
                    Console.WriteLine("1.Sort by weight");
                    Console.WriteLine("2.Sort by parked time");
                    Console.WriteLine("3.Exit");
                    int choice = int.Parse(Console.ReadLine());
                    try
                    {
                        switch (choice)
                        {
                            case 1:
                                // Sort using IComparable (by weight)
                                listVehicles.Sort();

                                Console.Write(
                                    "{0,-15} {1,-10} {2,-12} {3,-7} {4}\n",
                                    "Registration No", "Name", "Type", "Weight", "Ticket No"
                                );

                                foreach (Vehicle v in listVehicles)
                                {
                                    Console.Write(
                                        "{0,-15} {1,-10} {2,-12} {3,-7:0.0} {4}\n",
                                        v.RegistrationNo, v.Name, v.Type, v.Weight, v.Ticket.TicketNo
                                    );
                                }
                                break;

                            case 2:
                                // Sort using IComparer (by parked time)
                                listVehicles.Sort(new parkedTimeComparer());

                                Console.Write(
                                    "{0,-15} {1,-10} {2,-12} {3,-7} {4}\n",
                                    "Registration No", "Name", "Type", "Weight", "Ticket No"
                                );

                                foreach (Vehicle v in listVehicles)
                                {
                                    Console.Write(
                                        "{0,-15} {1,-10} {2,-12} {3,-7:0.0} {4}\n",
                                        v.RegistrationNo, v.Name, v.Type, v.Weight, v.Ticket.TicketNo
                                    );
                                }
                                break;

                            case 3:
                                flag = false;
                                break;

                            default:
                                Console.WriteLine("Invalid Choice");
                                break;
                        }
                    }
                    catch (FormatException)
                    {
                        // Handles invalid number or date format
                        Console.WriteLine("Invalid input format");
                    }
                }
            }
            catch (Exception)
            {
                // Handles unexpected runtime errors
                Console.WriteLine("An unexpected error occurred");
            }
        }
    }
}
