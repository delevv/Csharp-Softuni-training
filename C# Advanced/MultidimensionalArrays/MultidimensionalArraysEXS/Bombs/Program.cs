using System;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void RemoveDemage(int[,] matrix, int row, int col, int demage)
        {
            if (row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1))
            {
                if (matrix[row, col] > 0)
                {
                    matrix[row, col] -= demage;
                }
            }
        }
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());

            var matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }
            var bombsIndexes = Console.ReadLine().Split();

            for (int i = 0; i < bombsIndexes.Length; i++)
            {
                var bombPlace = bombsIndexes[i].Split(",");
                var bombRow = int.Parse(bombPlace[0]);
                var bombCol = int.Parse(bombPlace[1]);
                var bombPower = matrix[bombRow, bombCol];

                if (bombPower > 0)
                {
                    RemoveDemage(matrix, bombRow - 1, bombCol - 1, bombPower);

                    RemoveDemage(matrix, bombRow - 1, bombCol + 1, bombPower);

                    RemoveDemage(matrix, bombRow - 1, bombCol, bombPower);

                    RemoveDemage(matrix, bombRow, bombCol - 1, bombPower);

                    RemoveDemage(matrix, bombRow, bombCol + 1, bombPower);

                    RemoveDemage(matrix, bombRow + 1, bombCol - 1, bombPower);

                    RemoveDemage(matrix, bombRow + 1, bombCol + 1, bombPower);

                    RemoveDemage(matrix, bombRow + 1, bombCol, bombPower);

                    matrix[bombRow, bombCol] = 0;
                }
            }
            var aliveCells = matrix.Cast<int>().Where(x => x > 0).Count();
            var aliveCellsSum = matrix.Cast<int>().Where(x => x > 0).Sum();

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {aliveCellsSum}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}