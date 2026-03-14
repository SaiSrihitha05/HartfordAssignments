using System;

namespace Requirement2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name of the Parking Lot:");
            string parkingLotName = Console.ReadLine();
            // Only one ParkingLot instance
            ParkingLot p1 = new ParkingLot(parkingLotName, new List<Vehicle>());
            bool flag = true;
            while (flag)
            {
                try
                {
                    Console.WriteLine("1.Add Vehicle");
                    Console.WriteLine("2.Delete Vehicle");
                    Console.WriteLine("3.Display Vehicles");
                    Console.WriteLine("4.Exit");
                    Console.WriteLine("Enter your choice:");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter Vehicle Details");
                            string input = Console.ReadLine();
                            Vehicle veh = Vehicle.CreateVehicle(input);
                            p1.AddVehicleToParkingLot(veh);
                            Console.WriteLine("Vehicle successfully added");
                            break;

                        case 2:
                            Console.WriteLine("Enter the registration number of the vehicle to be deleted:");
                            string regNo = Console.ReadLine();
                            bool removed = p1.RemoveVehicleFromParkingLot(regNo);
                            if (removed)
                                Console.WriteLine("Vehicle successfully deleted");
                            else
                                Console.WriteLine("Vehicle not found in parkinglot");
                            break;

                        case 3:
                            p1.DisplayVehicles();
                            break;

                        case 4:
                            flag = false;
                            break;

                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
                catch (FormatException)
                {
                    // Handles invalid number or date format
                    Console.WriteLine("Invalid input format");
                }
                catch (IndexOutOfRangeException)
                {
                    // Handles missing input values
                    Console.WriteLine("Insufficient input data");
                }
                catch (Exception)
                {
                    // Handles unexpected runtime errors
                    Console.WriteLine("An unexpected error occurred");
                }
            }


        }
    }
}
