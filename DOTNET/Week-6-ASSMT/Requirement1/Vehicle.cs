using System;

namespace Requirement1
{
    public class Vehicle
    {
        public Vehicle()
        {
        }

        public Vehicle(string _registrationNo, string _name, string _type, double _weight, Ticket _ticket)
        {
            this._registrationNo = _registrationNo;
            this._name = _name;
            this._type = _type;
            this._weight = _weight;
            this._ticket = _ticket;
        }

        private string _registrationNo;

        public string RegistrationNo
        {
            get { return _registrationNo; }
            set { _registrationNo = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _type;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private double _weight;

        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        private Ticket _ticket;

        public Ticket Ticket
        {
            get { return _ticket; }
            set { _ticket = value; }
        }

        // Displays vehicle details in required format
        public override string ToString()
        {
            return $"Registration No:{_registrationNo}\n" +
                   $"Name:{_name}\n" +
                   $"Type:{_type}\n" +
                   $"Weight:{_weight:0.0}\n" +
                   $"Ticket No:{_ticket.TicketNo}";
        }

        // Vehicles are equal if registration number and name match (case-insensitive)
        public override bool Equals(object? obj)
        {
            if (obj is not Vehicle veh) return false;

            return _registrationNo.Equals(veh._registrationNo, StringComparison.OrdinalIgnoreCase)
                && _name.Equals(veh._name, StringComparison.OrdinalIgnoreCase);
        }

        // Must be overridden when Equals is overridden
        public override int GetHashCode()
        {
            return HashCode.Combine(
                _registrationNo?.ToLower(),
                _name?.ToLower()
            );
        }
    }
}
