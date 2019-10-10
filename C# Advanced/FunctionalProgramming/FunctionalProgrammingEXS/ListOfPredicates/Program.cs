using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxNumber = int.Parse(Console.ReadLine());
            var divideNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var numbers = new List<int>();

            for (int i = 1; i <= maxNumber; i++)
            {
                numbers.Add(i);
            }

            Func<int, int[], bool> divideFunc = (num, divideNums) =>
            {
                   bool isDivide = true;

                   foreach (var divideNum in divideNums)
                   {
                       if (num % divideNum != 0)
                       {
                           isDivide = false;
                       }
                   }
                   return isDivide;
            };

            numbers = numbers
                .Where(x => divideFunc(x, divideNumbers))
                .ToList();

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
