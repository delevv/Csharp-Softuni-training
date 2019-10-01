using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixRows = int.Parse(Console.ReadLine());

            var matrix = new int[matrixRows, matrixRows];

            for (int row= 0; row < matrixRows; row++)
            {
                var numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < numbers.Length; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }
            var firstDiagonalSum = 0;
            var secondDiagonalSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                firstDiagonalSum += matrix[row, row];
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                secondDiagonalSum += matrix[row, matrix.GetLength(1)-row-1];
            }
            var difference = Math.Abs(firstDiagonalSum - secondDiagonalSum);

            Console.WriteLine(difference);
        }
    }
}
