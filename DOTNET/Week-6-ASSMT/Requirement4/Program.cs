using System;
using System.Collections.Generic;

namespace Requirement4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VehicleBO vehicleBO = new VehicleBO();
            List<Vehicle> listVehicles = new List<Vehicle>();

            try
            {
                Console.WriteLine("Enter number of vehicles");
                int noOfVehicles = int.Parse(Console.ReadLine());
                Console.WriteLine($"Enter {noOfVehicles} vehicles details");
                // Reading vehicle details and creating Vehicle objects
                for (int i = 0; i < noOfVehicles; i++)
                {
                    string input = Console.ReadLine();
                    Vehicle vh = Vehicle.CreateVehicle(input);
                    listVehicles.Add(vh);
                }

                bool flag = true;

                while (flag)
                {
                    Console.WriteLine("Enter a search type:");
                    Console.WriteLine("1.By type");
                    Console.WriteLine("2.By parked time");
                    Console.WriteLine("3.Exit");

                    int choice = int.Parse(Console.ReadLine());

                    try
                    {
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("Enter the vehicle type");
                                string type = Console.ReadLine();
                                List<Vehicle> listVehiclesByType =vehicleBO.FindVehicle(listVehicles, type);
                                if (listVehiclesByType.Count == 0)
                                {
                                    Console.WriteLine("No such vehicle is present");
                                    break;
                                }
                                Console.Write("{0,-15} {1,-10} {2,-12} {3,-7} {4}\n","Registration No", "Name", "Type", "Weight", "Ticket No");
                                foreach (Vehicle v in listVehiclesByType)
                                {
                                    Console.Write("{0,-15} {1,-10} {2,-12} {3,-7:0.0} {4}\n",v.RegistrationNo, v.Name, v.Type, v.Weight, v.Ticket.TicketNo);
                                }
                                break;

                            case 2:
                                Console.WriteLine("Enter the parked time:");
                                DateTime dt = DateTime.ParseExact(Console.ReadLine(),"dd-MM-yyyy HH:mm:ss",null);
                                List<Vehicle> listVehiclesByTime =vehicleBO.FindVehicle(listVehicles, dt);
                                if (listVehiclesByTime.Count == 0)
                                {
                                    Console.WriteLine("No such vehicle is present");
                                    break;
                                }
                                Console.Write("{0,-15} {1,-10} {2,-12} {3,-7} {4}\n","Registration No", "Name", "Type", "Weight", "Ticket No");
                                foreach (Vehicle v in listVehiclesByTime)
                                {
                                    Console.Write("{0,-15} {1,-10} {2,-12} {3,-7:0.0} {4}\n",v.RegistrationNo, v.Name, v.Type, v.Weight, v.Ticket.TicketNo);
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
                        // Handles invalid date/number formats
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
