using System;
using System.Linq;

namespace ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] arrayOne = new int[n];
            int[] arrayTwo = new int[n];

            int indexOne = 0;
            int indexTwo = 0;

            for (int i = 1; i <= n; i++)
            {
                int[] currentArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (i % 2 == 1)
                {
                    arrayOne[indexOne] = currentArray[0];
                    indexOne++;
                    arrayTwo[indexTwo] = currentArray[1];
                    indexTwo++;
                }
                else
                {
                    arrayOne[indexOne] = currentArray[1];
                    indexOne++;
                    arrayTwo[indexTwo] = currentArray[0];
                    indexTwo++;
                }
            }
            Console.WriteLine(string.Join(" ", arrayOne));
            Console.WriteLine(string.Join(" ", arrayTwo));
        }
    }
}
