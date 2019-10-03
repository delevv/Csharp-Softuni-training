using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
            var dictionary = new Dictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                var currentNumber = numbers[i];

                if (!dictionary.ContainsKey(currentNumber))
                {
                    dictionary[currentNumber] = 1;
                }
                else
                {
                    dictionary[currentNumber]++;
                }
            }
            foreach (var number in dictionary)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
