using System;
using System.Collections.Generic;

namespace Requirement4
{
    internal class VehicleBO
    {
        // Finds vehicles matching the given type
        public List<Vehicle> FindVehicle(List<Vehicle> vehicleList, string type)
        {
            List<Vehicle> vehiclesWithGivenType = new List<Vehicle>();
            foreach (Vehicle vehicle in vehicleList)
            {
                if (vehicle.Type == type)
                {
                    vehiclesWithGivenType.Add(vehicle);
                }
            }
            return vehiclesWithGivenType;
        }

        // Finds vehicles matching the given parked time
        public List<Vehicle> FindVehicle(List<Vehicle> vehicleList, DateTime parkedTime)
        {
            List<Vehicle> vehiclesWithParkedTime = new List<Vehicle>();
            foreach (Vehicle vehicle in vehicleList)
            {
                if (vehicle.Ticket.ParkedTime == parkedTime)
                {
                    vehiclesWithParkedTime.Add(vehicle);
                }
            }
            return vehiclesWithParkedTime;
        }
    }
}
