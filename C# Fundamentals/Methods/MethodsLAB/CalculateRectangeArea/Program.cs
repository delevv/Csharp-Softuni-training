using System;

namespace CalculateRectangeArea
{
    class Program
    {
        static double RectangeArea(double width,double height)
        {
            return width * height;
        }
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine(RectangeArea(width,height));
        }
    }
}
