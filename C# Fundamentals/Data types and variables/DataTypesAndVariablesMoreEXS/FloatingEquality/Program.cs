using System;

namespace FloatingEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double eps = 0.000001;
            double diff = Math.Abs(a - b);

            bool isEqual = eps >= diff;
            Console.WriteLine(isEqual);

        }
    }
}
