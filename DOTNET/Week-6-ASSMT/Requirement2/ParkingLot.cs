using System;
using System.Collections.Generic;
using System.Linq;

namespace Requirement2
{
    public class ParkingLot
    {
        // Constructor receives name and an empty vehicle list
        public ParkingLot(string _name, List<Vehicle> _vehicleList)
        {
            this._name = _name;
            this._vehicleList = _vehicleList;
        }

        private string _name;
        private List<Vehicle> _vehicleList;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<Vehicle> VehicleList
        {
            get { return _vehicleList; }
            set { _vehicleList = value; }
        }

        public void AddVehicleToParkingLot(Vehicle vehicle)
        {
            _vehicleList.Add(vehicle);
        }

        public bool RemoveVehicleFromParkingLot(string registrationNo)
        {
            Vehicle found = _vehicleList.FirstOrDefault(v => v.RegistrationNo.Equals(registrationNo, StringComparison.OrdinalIgnoreCase));

            if (found != null)
            {
                _vehicleList.Remove(found);
                return true;
            }

            return false;
        }

        public void DisplayVehicles()
        {
            if (_vehicleList.Count == 0)
            {
                Console.WriteLine("No vehicles to show");
            }
            else
            {
                Console.WriteLine($"Vehicles in {_name}");
                Console.Write("{0,-15} {1,-10} {2,-12} {3,-7} {4}\n","Registration No", "Name", "Type", "Weight", "Ticket No");
                foreach (Vehicle v in _vehicleList)
                {
                    Console.Write("{0,-15} {1,-10} {2,-12} {3,-7:0.0} {4}\n",v.RegistrationNo,v.Name,v.Type,v.Weight,v.Ticket.TicketNo);
                }
            }
        }
    }
}
