using System;
using System.Linq;

namespace MaxSequenceOfElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int longest = 0;
            int element = 0;
            int count = 1;
            for (int i = 0; i < numbers.Length-1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    count++;
                    if (count > longest)
                    {
                        longest = count;
                        element = numbers[i];
                    }
                }
                else count = 1;
            }
            for (int i = 0; i < longest; i++)
            {
                Console.Write(element+ " ");
            }
        }
    }
}
