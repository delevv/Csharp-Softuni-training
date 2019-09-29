using System;
using System.Linq;

namespace PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixSize = int.Parse(Console.ReadLine());

            var matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                var matrixRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = matrixRow[col];
                }
            }
            var colIndex = 0;
            var sum = 0;
            
            for (int i = 0; i < matrixSize; i++)
            {
                sum += matrix[i, colIndex];
                colIndex++;
            }
            Console.WriteLine(sum);
        }
    }
}
