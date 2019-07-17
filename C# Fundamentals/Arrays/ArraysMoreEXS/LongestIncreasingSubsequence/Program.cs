using System;
using System.Linq;

namespace LongestIncreasingSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] lenght = new int[numbers.Length];
            int[] previous = new int[numbers.Length];
            int maxLenght = 0;
            int lastIndex = -1;

            for (int x = 0; x < numbers.Length; x++)
            {
                lenght[x] = 1;
                previous[x] = -1;
                for (int i = 0; i < x; i++)
                {
                    if ((numbers[i] < numbers[x]) && (lenght[i] + 1 > lenght[x]))
                    {
                        lenght[x] = lenght[i] + 1;
                        previous[x] = i;
                    }
                }
                if (lenght[x] > maxLenght)
                {
                    maxLenght = lenght[x];
                    lastIndex = x;
                }

            }
            int[] bestSequence = new int[maxLenght];
            int index = maxLenght - 1;
            while (lastIndex != -1)
            {
                bestSequence[index] = numbers[lastIndex];
                index--;
                lastIndex = previous[lastIndex];
            }
            Console.WriteLine(string.Join(" ", bestSequence));

        }
    }
}
