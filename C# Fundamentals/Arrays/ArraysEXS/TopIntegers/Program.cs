using System;
using System.Linq;

namespace TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                bool isBigger = true;
                for (int k = i; k < numbers.Length-1; k++)
                {
                    if (numbers[i] <= numbers[k + 1]) isBigger = false;
                }
                if (isBigger) Console.Write(numbers[i]+ " ");
            }
        }
    }
}
