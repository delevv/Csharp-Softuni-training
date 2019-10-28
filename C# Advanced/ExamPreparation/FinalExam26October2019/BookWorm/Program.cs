using System;

namespace BookWorm
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentString = Console.ReadLine();
            var rowsAndCols = int.Parse(Console.ReadLine());

            var field = new char[rowsAndCols, rowsAndCols];

            var playerRow = 0;
            var playerCol = 0;

            for (int row = 0; row < rowsAndCols; row++)
            {
                var currentRow = Console.ReadLine();

                for (int col = 0; col < rowsAndCols; col++)
                {
                    field[row, col] = currentRow[col];

                    if (currentRow[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            var command = "";

            while ((command = Console.ReadLine()) != "end")
            {
                field[playerRow, playerCol] = '-';

                var row = 0;
                var col = 0;

                if (command == "up")
                {
                    row = -1;
                }
                else if (command == "down")
                {
                    row = 1;
                }
                else if (command == "left")
                {
                    col = -1;
                }
                else if (command == "right")
                {
                    col = 1;
                }

                if(playerRow+row>=0 && playerRow+row<field.GetLength(0) && playerCol+col>=0 && playerCol + col < field.GetLength(1))
                {
                    playerRow += row;
                    playerCol += col;

                    if (field[playerRow, playerCol] != '-')
                    {
                        currentString += field[playerRow, playerCol];
                    }
                }
                else
                {
                    if (currentString.Length > 0)
                    {
                        currentString = currentString.Remove(currentString.Length - 1);
                    }
                }

                field[playerRow, playerCol] = 'P';
            }
            Console.WriteLine(currentString);

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(0); col++)
                {
                    Console.Write(field[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
