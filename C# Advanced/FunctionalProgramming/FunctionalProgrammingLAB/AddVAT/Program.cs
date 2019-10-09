using System;
using System.Linq;

namespace AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var prices = Console.ReadLine()
                .Split(", ")
                .Select(double.Parse)
                .Select(x => x * 1.20);

            foreach (var price in prices)
            {
                Console.WriteLine($"{price:f2}");
            }
        }
    }
}
