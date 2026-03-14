namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Sai Srihitha");

            int res = sum(3, 4);
            Console.WriteLine(res);


            float divres = divide(10, 5);
            Console.WriteLine(divres);


            Console.WriteLine(-1 + 4 * 6);


            swap(3, 4);


            double result=multiply(2.4, 5.6, 7.8);
            Console.WriteLine(result);


            int multiplyTable = 5;
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{multiplyTable}*{i}={multiplyTable*i}");
            }


            Console.WriteLine("Enter you age:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine($"your age is {age}");
        }
        static int sum(int a,int b)
        {
            return a + b;
        }
        static float divide(int a, int b)
        {
            return a / b;
        }
        static void swap(int a,int b)
        {
            Console.WriteLine("Before Swap: {0} {1}", a, b);
            int c = a;
            a = b;
            b = c;
            Console.WriteLine("After Swap: {0} {1}",a,b);
        }
        static double multiply(double a,double b,double c)
        {
            return a * b * c;
        }
    }
}
