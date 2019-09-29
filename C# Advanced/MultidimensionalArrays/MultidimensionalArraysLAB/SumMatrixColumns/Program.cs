using System;
using System.Linq;

namespace SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            var info = Console.ReadLine().Split(", ");
            var rows = int.Parse(info[0]);
            var cols = int.Parse(info[1]);

            var array = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var rowNumbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = rowNumbers[j];
                }
            }
            var sum = 0;

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    sum += array[j, i];
                }
                Console.WriteLine(sum);
                sum = 0;
            }
        }
    }
}
