using System;

namespace MetersToKm
{
    class Program
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());
            Console.WriteLine("{0:f2}",meters/1000.00);
        }
    }
}
