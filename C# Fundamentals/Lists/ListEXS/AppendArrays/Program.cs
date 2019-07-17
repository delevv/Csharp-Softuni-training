using System;
using System.Collections.Generic;
using System.Linq;

namespace AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbersAsString = Console.ReadLine().Split('|').Reverse().ToList();

            List<int> reversedNumbers = new List<int>();

            for (int i = 0; i < numbersAsString.Count; i++)
            {
                List<int> currentNumbers = numbersAsString[i].Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                reversedNumbers.AddRange(currentNumbers);
            }
            Console.WriteLine(string.Join(" ",reversedNumbers));
        }
    }
}
