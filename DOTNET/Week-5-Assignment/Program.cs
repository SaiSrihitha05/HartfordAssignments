namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("First:");
            Console.WriteLine("Enter n: ");
            first(int.Parse(Console.ReadLine()));


            Console.WriteLine("\n\n");
            //Console.WriteLine(res);
            Console.WriteLine("Second:");
            Console.WriteLine("Enter xA:");
            int xA = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter yA:");
            int yA = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter rA:");
            int radA = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter xB:");
            int xB = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter yB:");
            int yB = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter rB:");
            int radB = int.Parse(Console.ReadLine());
            string res = Second(xA, xB, yA, yB, radA, radB);
            Console.WriteLine(res);


            Console.WriteLine("\n\n");
            Console.WriteLine("Third:");
            Console.WriteLine("Enter Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine());
            double salary = ClassLibrary2.Class1.CalculateNetSalary(baseSalary);
            Console.WriteLine($"Salary after Deductions and Additions: {salary}");


            Console.WriteLine("\n\n");
            Console.WriteLine("Fourth:");
            //For input get Customerld, CustomerName, Address, PhoneNumber, Emailld,
            //Type of connection(Industrial, Business, Domestic, Agricultural), Previous Reading, Current Reading.
            Console.WriteLine("Enter Customer Id:");
            int customerId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Customer Name:");
            string customerName = Console.ReadLine();
            Console.WriteLine("Enter Address:");
            string address = Console.ReadLine();
            Console.WriteLine("Enter Phone Number:");
            long phoneNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter Email Id:");
            string emailId = Console.ReadLine();
            Console.WriteLine("Enter Type of Connection:");
            string connectionType = Console.ReadLine();
            Console.WriteLine("Enter Previous Reading:");
            int previousReading = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Current Reading:");
            int currentReading = int.Parse(Console.ReadLine());
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("\n---------- Electricity Bill ------------");
            Console.WriteLine($"Customer Id: {customerId}");
            Console.WriteLine($"Customer Name: {customerName}");
            Console.WriteLine($"Address: {address}");
            Console.WriteLine($"Connection Type: {connectionType}");
            Console.WriteLine($"Previous Reading {previousReading}");
            Console.WriteLine($"Current Reading: {currentReading}");
            double result = Fourth(previousReading, currentReading, connectionType);
            Console.WriteLine($"Total Bill: {result}");
            Console.WriteLine("-------------------------------------");

            Console.WriteLine("\n\n");
            Console.WriteLine("Fifth:");
            Console.WriteLine("Enter Weight: ");
            int weight=int.Parse(Console.ReadLine());
            string category = Fifth(weight);
            Console.WriteLine($"U fall under category: {category}");

        }

        static void first(int n)
        {
            int res = 0;
            int val = 0;

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(res);
                int diff = i * (i + 1) * (3); 
                res = res + diff;
                
            }

        }

        static string Second(int xA,int xB,int yA,int yB,int radA,int radB)
        {
            int dx = xA - xB;
            int dy = yA - yB;
            int distance = (dx * dx + dy * dy);
            int radDiff = Math.Abs(radA - radB);
            int radSum = radA + radB;
            if (distance <= radDiff * radDiff)
            {
                if (radA > radB)
                   return "B is in A";
                else
                    return "A is in B";
            }
            else if (distance < radSum * radSum)
            {
                return "A and B intersect";
            }
            else
            {
                return "A and B do not intersect";
            }


        }
        static double Fourth(int previousReading, int currentReading,string connectionType)
        {

            int units = currentReading - previousReading;
            double electricityCharge = 0;
            double meterRent = 0;

            if (units <= 100)
                electricityCharge = units * 1.5;
            else if (units <= 250)
                electricityCharge = (100 * 1.5) + ((units - 100) * 2.5);
            else if (units <= 550)
                electricityCharge = (100 * 1.5) + (150 * 2.5) + ((units - 250) * 4.5);
            else
                electricityCharge = (100 * 1.5) + (150 * 2.5) + (300 * 4.5) + ((units - 550) * 7.5);

            connectionType = connectionType.ToLower();

            if (connectionType == "industrial")
                meterRent = 2500;
            else if (connectionType == "business")
                meterRent = 1500;
            else if (connectionType == "domestic")
                meterRent = 1000;
            else if (connectionType == "agricultural")
                meterRent = 0;

            Console.WriteLine($"Units Consumed: {electricityCharge}");
            Console.WriteLine($"Meter Rent: {meterRent}");
            double totalBill = electricityCharge + meterRent;
            return totalBill;

        }
        static string Fifth(int weight)
        {
            int num;
            if (weight < 0 || weight>120)
            {
                return "Invalid Input";
            }
            if (weight <= 48) num = 0;
            else if (weight <= 52) num = 1;
            else if (weight <= 54) num = 2;
            else if (weight <= 57) num = 3;
            else if (weight <= 60) num = 4;
            else if (weight <= 64) num = 5;
            else if (weight <= 69) num = 6;
            else if (weight <= 75) num = 7;
            else if (weight <= 81) num = 8;
            else if (weight <= 91) num = 9;
            else num = 10;
            switch (num)
                {
                case 0: return "light fly";
                case 1: return "fly";
                case 2: return "bantam";
                case 3: return "feather";
                case 4: return "light";
                case 5: return "light welter";
                case 6: return "welter";
                case 7: return "light middle";
                case 8: return "middle";
                case 9: return "light heavy";
                case 10: return "heavy";
                default: return "Invalid Input";
            }
        }

    }
}
