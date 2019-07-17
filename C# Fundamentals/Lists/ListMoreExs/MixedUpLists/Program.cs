using System;
using System.Collections.Generic;
using System.Linq;

namespace MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> mixedNumbers = new List<int>();

            secondNumbers.Reverse();

            for (int i = 0; i < Math.Max(firstNumbers.Count,secondNumbers.Count); i++)
            {
                mixedNumbers.Add(firstNumbers[i]);
                mixedNumbers.Add(secondNumbers[i]);

                if (Math.Min(firstNumbers.Count, secondNumbers.Count) == i + 1)
                {
                    break;
                }
            }

            int range1 = 0;
            int range2 = 0;

            if (firstNumbers.Count > secondNumbers.Count)
            {
                range1 = firstNumbers[firstNumbers.Count - 1];
                range2 = firstNumbers[firstNumbers.Count - 2];
            }
            else
            {
                range1 = secondNumbers[secondNumbers.Count - 1];
                range2 = secondNumbers[secondNumbers.Count - 2];
            }

            mixedNumbers.Sort();

            for (int i = 0; i < mixedNumbers.Count; i++)
            {
                if(mixedNumbers[i]>Math.Min(range1,range2) && mixedNumbers[i] < Math.Max(range1, range2))
                {
                    Console.Write(mixedNumbers[i]+ " ");
                }
            }
        }
    }
}
