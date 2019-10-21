using System;
using System.Linq;

namespace TronRacers
{
    class Program
    {
        static void Print(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row,col]);
                }
                Console.WriteLine();
            }
        }
        static bool IsInside(char[,] field, int row, int col)
        {
            return row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1);
        }
        static void Main(string[] args)
        {
            var rowsAndCols = int.Parse(Console.ReadLine());

            var field = new char[rowsAndCols, rowsAndCols];

            var firstRow = 0;
            var firstCol = 0;

            var secondRow = 0;
            var secondCol = 0;

            for (int row = 0; row < rowsAndCols; row++)
            {
                var currentRow = Console.ReadLine();

                for (int col = 0; col < currentRow.Length; col++)
                {
                    field[row, col] = currentRow[col];

                    if (currentRow[col] == 'f')
                    {
                        firstRow = row;
                        firstCol = col;
                    }
                    if (currentRow[col] == 's')
                    {
                        secondRow = row;
                        secondCol = col;
                    }
                }
            }

            while (true)
            {
                var commands = Console.ReadLine().Split();

                var firstPlayerCommand = commands[0];
                var secondPlayerCommand = commands[1];

                for (int i = 1; i <= 2; i++)
                {
                    var row = firstRow;
                    var col = firstCol;
                    var command = firstPlayerCommand;

                    if (i == 2)
                    {
                        row = secondRow;
                        col = secondCol;
                        command = secondPlayerCommand;
                    }

                    if (command == "up")
                    {
                        row -= 1;

                        if (!IsInside(field, row, col))
                        {
                            row = rowsAndCols-1;
                        }
                    }
                    else if (command == "down")
                    {
                        row += 1;

                        if (!IsInside(field, row, col))
                        {
                            row = 0 ;
                        }
                    }
                    else if (command == "left")
                    {
                        col -= 1;

                        if (!IsInside(field, row, col))
                        {
                            col = rowsAndCols - 1;
                        }
                    }
                    else if (command == "right")
                    {
                        col += 1;

                        if (!IsInside(field, row, col))
                        {
                            col = 0;
                        }
                    }

                    if (i == 1)
                    {
                        if (field[row, col] == 's')
                        {
                            field[row, col] = 'x';
                            Print(field);
                            return;
                        }
                        else
                        {
                            field[row, col] = 'f';

                            firstRow = row;
                            firstCol = col;
                        }
                    }
                    else if (i == 2)
                    {
                        if (field[row, col] == 'f')
                        {
                            field[row, col] = 'x';
                            Print(field);
                            return;
                        }
                        else
                        {
                            field[row, col] = 's';

                            secondRow = row;
                            secondCol = col;
                        }
                    }
                }
            }
        }
    }
}
