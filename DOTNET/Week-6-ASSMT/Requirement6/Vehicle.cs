using System;

namespace Requirement6
{
    public class Vehicle
    {
        public Vehicle()
        {
        }

        public Vehicle(string _registrationNo, string _name, string _type, double _weight)
        {
            this._registrationNo = _registrationNo;
            this._name = _name;
            this._type = _type;
            this._weight = _weight;
        }

        private string _registrationNo;
        private string _name;
        private string _type;
        private double _weight;


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


        // Creates a Vehicle object from comma-separated input string
        public static Vehicle CreateVehicle(string detail)
        {
            string[] input = detail.Split(',');
            Vehicle vehicle = new Vehicle(input[0], input[1], input[2], double.Parse(input[3]));
            return vehicle;
        }

        public static SortedDictionary<string, int> TypeWiseCount(List<Vehicle> vehicleList)
        {
            
            SortedDictionary<string, int> sortedDict = new SortedDictionary<string, int>();
            foreach(Vehicle v in vehicleList)
            {
                // Normalize type to handle "TwoWheeler" and "Two Wheeler"
                string normalizedType = v.Type.Replace(" ", "").ToLower();
                string displayType = normalizedType == "twowheeler" ? "TwoWheeler" :normalizedType == "fourwheeler" ? "FourWheeler" :v.Type;
                if (sortedDict.ContainsKey(displayType))
                {
                    sortedDict[displayType] += 1;
                }
                else
                {
                    sortedDict[displayType] = 1;
                }
            }
            return sortedDict;
        }
    }
}
