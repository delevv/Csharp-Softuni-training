using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var setsCount = Console.ReadLine().Split(" ");

            var firstSet = int.Parse(setsCount[0]);
            var secondSet = int.Parse(setsCount[1]);

            var firstNumbers = new HashSet<int>();
            var secondNumbers = new HashSet<int>();

            for (int i = 0; i < firstSet+secondSet; i++)
            {
                var currentNumber = int.Parse(Console.ReadLine());

                if (i < firstSet)
                {
                    firstNumbers.Add(currentNumber);
                }
                else
                {
                    secondNumbers.Add(currentNumber);
                }
            }
            Console.WriteLine(string.Join(" ",firstNumbers.Intersect(secondNumbers)));
        }
    }
}
