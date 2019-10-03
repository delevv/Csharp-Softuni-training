using System;
using System.Linq;

namespace Miner
{
    class Program
    {
        static bool IsInside(char[,] field, int row, int col)
        {
            return row >= 0 && row < field.GetLength(0) &&
                col >= 0 && col < field.GetLength(1);
        }
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var commands = Console.ReadLine().Split();

            var field = new char[size, size];
            var startRow = 0;
            var startCol = 0;
            var coalsCount = 0;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                var line = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = line[col];

                    if (field[row, col] == 's')
                    {
                        startRow = row;
                        startCol = col;
                    }
                    if (field[row, col] == 'c')
                    {
                        coalsCount++;
                    }
                }
            }
            var isFinished = false;

            for (int i = 0; i < commands.Length; i++)
            {
                var direction = commands[i];
                var currentSymbol = '*';

                if (direction == "up")
                {
                    if (IsInside(field, startRow - 1, startCol))
                    {
                        currentSymbol = field[startRow - 1, startCol];
                        startRow -= 1;
                    }
                }
                else if (direction == "down")
                {
                    if (IsInside(field, startRow + 1, startCol))
                    {
                        currentSymbol = field[startRow + 1, startCol];
                        startRow += 1;
                    }
                }
                else if (direction == "left")
                {
                    if (IsInside(field, startRow , startCol-1))
                    {
                        currentSymbol = field[startRow, startCol-1];
                        startCol-=1;
                    }
                }
                else if (direction == "right")
                {
                    if (IsInside(field, startRow, startCol+1))
                    {
                        currentSymbol = field[startRow , startCol+1];
                        startCol += 1 ;
                    }
                }
                if (currentSymbol == 'c')
                {
                    coalsCount--;
                    field[startRow, startCol] = '*';

                    if (coalsCount == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                        isFinished = true;
                        break;
                    }
                }
                else if (currentSymbol == 'e')
                {
                    Console.WriteLine($"Game over! ({startRow}, {startCol})");
                    isFinished = true;
                    break;
                }
            }
            if (!isFinished)
            {
                Console.WriteLine($"{coalsCount} coals left. ({startRow}, {startCol})");
            }
        }
    }
}
