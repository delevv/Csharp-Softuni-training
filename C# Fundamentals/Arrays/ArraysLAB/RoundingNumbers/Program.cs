using System;
using System.Linq;

namespace RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                double currentNum = numbers[i];
                int roundedNum = (int)Math.Round(currentNum, MidpointRounding.AwayFromZero);
                Console.WriteLine($"{currentNum} => {roundedNum}");
            }
        }
    }
}
