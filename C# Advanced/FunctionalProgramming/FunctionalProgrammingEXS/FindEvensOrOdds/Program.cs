using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrayInfo = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var lowerBound = arrayInfo[0];
            var upperBound = arrayInfo[1];

            var evenOrOdd = Console.ReadLine();

            Predicate<int> isEvenPredicate = num => num % 2 == 0;

            var numbers = new List<int>();

            for (int i = lowerBound; i <= upperBound; i++)
            {
                numbers.Add(i);
            }

            if (evenOrOdd == "even")
            {
                numbers.RemoveAll(x => !isEvenPredicate(x));
            }
            else
            {
                numbers.RemoveAll(x => isEvenPredicate(x));
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
