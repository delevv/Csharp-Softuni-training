using System;
using System.Linq;

namespace SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var info = Console.ReadLine().Split(", ");
            var rows = int.Parse(info[0]);
            var cols = int.Parse(info[1]);

            var array = new int[rows, cols];
            var sum = 0;

            for (int i = 0; i < rows; i++)
            {
                var rowNumbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = rowNumbers[j];
                    sum += rowNumbers[j];
                }
            }
            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }
    }
}
