using System;

namespace DelegatesEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            #region TaskHW10_1
            Tabulation(Sinus, 1, 10, 5);
            Console.WriteLine();

            Tabulation(Function, 1, 10, 5);

            Console.ReadKey();
            #endregion
        }

        public delegate double Funct(double x);

        public static double Sinus(double x)
        {
            return Math.Sin(x);
        }

        public static double Function(double x)
        {
            //return Math.Pow(2 * x, 2) + 3 * x * Math.Cos(Math.Pow(x, 3);
            return ((2 * x) * (2 * x)) + 3 * x * Math.Cos(x * x * x);
        }

        public static void Tabulation(Funct fun, double a, double b, int n)
        {
            for (int k = 0; k < n; k++)
            {
                double result = a + k * (b - a) / n;
                Console.WriteLine($"{result}    {fun(result)}");
            }
            
        }
    }
}
