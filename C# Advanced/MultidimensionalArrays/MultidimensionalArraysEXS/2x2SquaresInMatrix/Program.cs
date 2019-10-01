using System;
using System.Linq;

namespace _2x2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndCols = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = rowsAndCols[0];
            var cols = rowsAndCols[1];

            var matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var symbols = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }
            var countOf2x2Matrix = 0;

            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                   if(matrix[row, col] == matrix[row, col + 1] 
                        && matrix[row + 1, col] == matrix[row + 1, col + 1] 
                        && matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        countOf2x2Matrix++;

                    }

                }
            }
            Console.WriteLine(countOf2x2Matrix);
        }
    }
}
