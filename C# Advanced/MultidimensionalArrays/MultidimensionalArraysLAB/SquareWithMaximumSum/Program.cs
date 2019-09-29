using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var info = Console.ReadLine().Split(", ");
            var rows = int.Parse(info[0]);
            var cols = int.Parse(info[1]);

            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var rowNumbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowNumbers[col];
                }
            }
            var bestRow = 0;
            var bestCol = 0;
            var bestSum = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                var sum = 0;

                for (int col = 0; col < cols - 1; col++)
                {
                    sum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }
            Console.WriteLine(matrix[bestRow, bestCol] + " " + matrix[bestRow, bestCol + 1]);
            Console.WriteLine(matrix[bestRow + 1, bestCol] + " " + matrix[bestRow + 1, bestCol + 1]);
            Console.WriteLine(bestSum);
        }
    }
}
