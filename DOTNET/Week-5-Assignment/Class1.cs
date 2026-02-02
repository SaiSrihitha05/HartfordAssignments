namespace ClassLibrary2
{
    public class Class1
    {
        public static double CalculateNetSalary(double basicSalary)
        {
            try
            {
                if (basicSalary < 0)
                {
                    throw new Exception("Basic salary should be greater than zero!!!!!");
                }
                double hra = 0.20 * basicSalary;
                double da = 0.10 * basicSalary;
                double pf = 0.12 * basicSalary;
                if (basicSalary < 15000)
                {
                    return basicSalary + hra + da;
                }
                return basicSalary + hra + da - pf;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return 0;
            }
        }
    }
}
