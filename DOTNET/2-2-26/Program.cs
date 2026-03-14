using System;
using System.Linq;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1️
            Console.WriteLine("Command-line args:");
            Console.WriteLine(string.Join(" ", args));
            Console.WriteLine();

            // 2️
            int x;
            GetValue(out x);
            Console.WriteLine("Value from out parameter: " + x);

            // 3️
            Console.WriteLine("Type of x: " + x.GetType());

            // 4️
            Console.WriteLine("x + 10 = " + (x + 10));
            Console.WriteLine();

            // 5️⃣
            string str = "Helolollolo";
            Console.WriteLine("Substring output: " + str.Substring(4, 6));
            Console.WriteLine();

            // 6️
            Random rand = new Random();
            Console.WriteLine("Random double value: " + rand.NextDouble());
            Console.WriteLine();

            // 7️
            Console.WriteLine("Sum using params:");
            Console.WriteLine(Sum(1, 2, 3, 4, 5, "hello"));
            Console.WriteLine();

            // 8
            Console.WriteLine("Enter integers (space-separated):");
            int[] arr = Console.ReadLine()
                              .Split(' ')
                              .Select(int.Parse)
                              .ToArray();

            Console.WriteLine("Array elements:");
            Console.WriteLine(string.Join(" ", arr));
            Console.WriteLine();

            // 9️
            var multiplied = arr.Select(n => n * 3);
            Console.WriteLine("After Select (x * 3):");
            Console.WriteLine(string.Join(" ", multiplied));
            Console.WriteLine();

            // 10
            var ascending = arr.OrderBy(n => n).ToArray();
            var descending = arr.OrderByDescending(n => n).ToArray();

            Console.WriteLine("Sorted Ascending:");
            Console.WriteLine(string.Join(" ", ascending));

            Console.WriteLine("Sorted Descending:");
            Console.WriteLine(string.Join(" ", descending));
        }

        static void GetValue(out int x)
        {
            x = 10;
        }
        static int Sum(params object[] nums)
        {
            int sum = 0;
            foreach (var item in nums)
            {
                if (item is int value)
                {
                    sum += value;
                }
                else
                {
                    Console.WriteLine("Ignored non-int: " + item);
                }
            }
            return sum;
        }
    }
}
