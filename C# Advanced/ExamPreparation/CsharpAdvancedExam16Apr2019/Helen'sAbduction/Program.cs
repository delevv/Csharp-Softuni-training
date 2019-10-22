using System;

namespace Helen_sAbduction
{
    class Program
    {
        static bool IsInside(char[][] field, int row, int col)
        {
            return row >= 0 && row < field.GetLength(0) && col >= 0 && col < field[row].Length;
        }
        static void Main(string[] args)
        {
            var energy = int.Parse(Console.ReadLine());
            var rows = int.Parse(Console.ReadLine());

            var field = new char[rows][];

            var parisRow = 0;
            var parisCol = 0;

            var helenRow = 0;
            var helenCol = 0;

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine();
                field[row] = new char[currentRow.Length];

                for (int col = 0; col < currentRow.Length; col++)
                {
                    var currentSymbol = currentRow[col];

                    field[row][col] = currentSymbol;

                    if (currentSymbol == 'P')
                    {
                        parisRow = row;
                        parisCol = col;
                    }
                    if (currentSymbol == 'H')
                    {
                        helenRow = row;
                        helenCol = col;
                    }
                }
            }

            while (true)
            {
                var commandInfo = Console.ReadLine().Split();

                var direction = commandInfo[0];
                var enemyRow = int.Parse(commandInfo[1]);
                var enemyCol = int.Parse(commandInfo[2]);

                field[enemyRow][enemyCol] = 'S';

                var rowMove = 0;
                var colMove = 0;

                if (direction == "up")
                {
                    rowMove = -1;
                }
                else if (direction == "down")
                {
                    rowMove = 1;
                }
                else if (direction == "left")
                {
                    colMove = -1;
                }
                else if (direction == "right")
                {
                    colMove = 1;
                }

                energy -= 1;

                if (IsInside(field, parisRow + rowMove, parisCol + colMove))
                {
                    field[parisRow][parisCol] = '-';

                    parisRow += rowMove;
                    parisCol += colMove;

                    if (field[parisRow][parisCol]== 'S')
                    {
                        energy -= 2;
                    }
                    else if (field[parisRow][parisCol] == 'H')
                    {
                        Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
                        field[parisRow][parisCol] = '-';
                        break;
                    }
                }

                if (energy <= 0)
                {
                    field[parisRow][parisCol] = 'X';
                    Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
                    break;
                }
            }
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    Console.Write(field[row][col]);
                }
                Console.WriteLine();
            }
        }
    }
}
