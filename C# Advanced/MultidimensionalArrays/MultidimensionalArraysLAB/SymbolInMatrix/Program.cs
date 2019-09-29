using System;

namespace SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixSize = int.Parse(Console.ReadLine());

            var matrix = new char[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                var characters = Console.ReadLine();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = characters[col];
                }
            }
            var specialSymbol = char.Parse(Console.ReadLine());

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var characters = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(matrix[row, col] == specialSymbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{specialSymbol} does not occur in the matrix");
        }
    }
}
