using System;

namespace LongerLine
{
    class Program
    {
        static void PrintLongestLine(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            double copyX1 = Math.Abs(x1);
            double copyY1 = Math.Abs(y1);
            double copyX2 = Math.Abs(x2);
            double copyY2 = Math.Abs(y2);
            double copyX3 = Math.Abs(x3);
            double copyY3 = Math.Abs(y3);
            double copyX4 = Math.Abs(x4);
            double copyY4 = Math.Abs(y4);
            if (copyX1 >= copyX3 && copyY1 >= copyY3 && copyX2 >= copyX4 && copyY2 >= copyY4)
            {
                if (copyX1 <= copyX2 && copyY1 <= copyY2)
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }
                else
                {
                    Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
                }
            }
            else
            {
                if (copyX3 <= copyX4 && copyY3 <= copyY4)
                {
                    Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
                }
                else
                {
                    Console.WriteLine($"({x4}, {y4})({x3}, {y3})");
                }
            }
        }
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            PrintLongestLine(x1, y1, x2, y2, x3, y3, x4, y4);
        }
    }
}
