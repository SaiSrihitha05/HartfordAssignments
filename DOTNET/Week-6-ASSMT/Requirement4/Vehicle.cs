using System;

namespace Requirement4
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
        private string _name;
        private string _type;
        private double _weight;
        private Ticket _ticket;


        public string RegistrationNo
        {
            get { return _registrationNo; }
            set { _registrationNo = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public Ticket Ticket
        {
            get { return _ticket; }
            set { _ticket = value; }
        }

        // Creates a Vehicle object from comma-separated input string
        public static Vehicle CreateVehicle(string detail)
        {
            string[] input = detail.Split(',');
            Ticket ticket = new Ticket(input[4], DateTime.ParseExact(input[5], "dd-MM-yyyy HH:mm:ss", null), double.Parse(input[6]));
            Vehicle vehicle = new Vehicle(input[0], input[1], input[2], double.Parse(input[3]), ticket);
            return vehicle;
        }
    }
}
