using System;

namespace PoundsToDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            double pounds = double.Parse(Console.ReadLine());
            Console.WriteLine("{0:f3}",pounds*1.31);
        }
    }
}
