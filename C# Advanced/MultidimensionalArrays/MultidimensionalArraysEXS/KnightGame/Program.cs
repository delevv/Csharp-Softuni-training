using System;

namespace KnightGame
{
    class Program
    {
        static bool IsInside(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());

            var matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                var currentRow = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            var knightsCount = 0;
            
            while (true)
            {
                var maxAttacks = 0;
                var killerRow = 0;
                var killerCol = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        var currentKnightAttacks = 0;

                        if (matrix[row, col] == 'K')
                        {
                            if (IsInside(matrix, row - 2, col + 1) && matrix[row - 2, col + 1] == 'K') currentKnightAttacks++;
                            if (IsInside(matrix, row - 2, col - 1) && matrix[row - 2, col - 1] == 'K') currentKnightAttacks++;
                            if (IsInside(matrix, row - 1, col + 2) && matrix[row - 1, col + 2] == 'K') currentKnightAttacks++;
                            if (IsInside(matrix, row - 1, col - 2) && matrix[row - 1, col - 2] == 'K') currentKnightAttacks++;
                            if (IsInside(matrix, row + 1, col + 2) && matrix[row + 1, col + 2] == 'K') currentKnightAttacks++;
                            if (IsInside(matrix, row + 1, col - 2) && matrix[row + 1, col - 2] == 'K') currentKnightAttacks++;
                            if (IsInside(matrix, row + 2, col + 1) && matrix[row + 2, col + 1] == 'K') currentKnightAttacks++;
                            if (IsInside(matrix, row + 2, col - 1) && matrix[row + 2, col - 1] == 'K') currentKnightAttacks++;
                        }
                        if (currentKnightAttacks > maxAttacks)
                        {
                            maxAttacks = currentKnightAttacks;
                            killerRow = row;
                            killerCol = col;
                        }
                    }
                }
                if (maxAttacks > 0)
                {
                    matrix[killerRow, killerCol] = '0';
                    knightsCount++;
                }
                else
                {
                    Console.WriteLine(knightsCount);
                    break;
                }
            }
        }
    }
}
