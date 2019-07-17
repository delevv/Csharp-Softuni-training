using System;

namespace CenterPoint
{
    class Program
    {
        static void PrintCenterPointOfTwo(double x1, double y1, double x2, double y2)
        {
            double copyX1 = Math.Abs(x1);
            double copyY1 = Math.Abs(y1);
            double copyX2 = Math.Abs(x2);
            double copyY2 = Math.Abs(y2);
            if (copyX1 <= copyX2 && copyY1 <= copyY2)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            PrintCenterPointOfTwo(x1, y1, x2, y2);
        }
    }
}
