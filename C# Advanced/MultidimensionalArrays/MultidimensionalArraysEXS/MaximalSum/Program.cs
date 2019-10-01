using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndCols = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = rowsAndCols[0];
            var cols = rowsAndCols[1];

            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var rowNumbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowNumbers[col];
                }
            }
            var bestRow = 0;
            var bestCol = 0;
            var bestSum = 0;

            for (int row = 0; row < rows - 2; row++)
            {
                var sum = 0;

                for (int col = 0; col < cols - 2; col++)
                {
                    sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {bestSum}");

            for (int row = bestRow; row <= bestRow+2; row++)
            {
                for (int col = bestCol; col <= bestCol+2; col++)
                {
                    Console.Write(matrix[row,col]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}