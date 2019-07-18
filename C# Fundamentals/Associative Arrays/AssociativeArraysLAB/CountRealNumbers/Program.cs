using System;
using System.Collections.Generic;
using System.Linq;

namespace CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var dict = new SortedDictionary<int, int>();

            foreach (var number in numbers)
            {
                if (!dict.ContainsKey(number))
                {
                    dict[number] = 0; ;
                }
                dict[number]++;
            }
            foreach (var number in dict)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}
