using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] rowsAndCols = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            int[,] matrix = new int[rows, cols];

            FillMatrix(rows, cols, matrix);

            var ivo = new Ivo();
            var evil = new Evil();

            string command = Console.ReadLine();

            while (command != "Let the Force be with you")
            {
                UpdateCoordinates(command, ivo, evil);
                MoveEvil(evil, matrix);
                MoveIvo(ivo, matrix);

                command = Console.ReadLine();
            }

            Console.WriteLine(ivo.CollectedStars);

        }
        private static void UpdateCoordinates(string command, Ivo ivo, Evil evil)
        {
            var ivoCoordinates = command
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            ivo.Move(ivoCoordinates[0], ivoCoordinates[1]);

            command = Console.ReadLine();

            var evilCoordinates = command
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            evil.Move(evilCoordinates[0], evilCoordinates[1]);
        }
        private static void FillMatrix(int rows, int cols, int[,] matrix)
        {
            int cellValue = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = cellValue++;
                }
            }
        }

        private static void MoveIvo(Ivo ivo, int[,] matrix)
        {
            while (ivo.Row >= 0)
            {
                if (ivo.Row < matrix.GetLength(0) && ivo.Col >= 0 && ivo.Col < matrix.GetLength(1))
                {
                    ivo.AddStars(matrix[ivo.Row, ivo.Col]);
                }

                ivo.Move(ivo.Row - 1, ivo.Col + 1);
            }
        }

        private static void MoveEvil(Evil evil, int[,] matrix)
        {
            while (evil.Row >= 0)
            {
                if (evil.Row < matrix.GetLength(0) && evil.Col >= 0 && evil.Col < matrix.GetLength(1))
                {
                    matrix[evil.Row, evil.Col] = 0;
                }
                evil.Move(evil.Row - 1, evil.Col - 1);
            }
        }
    }
}
