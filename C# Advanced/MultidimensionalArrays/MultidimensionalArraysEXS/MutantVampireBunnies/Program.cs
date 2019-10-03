using System;
using System.Collections.Generic;
using System.Linq;

namespace MutantVampireBunnies
{
    class Program
    {
        static bool IsInside(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
               col >= 0 && col < matrix.GetLength(1);
        }
        static char[,] BunnySpread(char[,] matrix, List<int> currentBunnies)
        {
            for (int i = 0; i < currentBunnies.Count; i += 2)
            {
                var row = currentBunnies[i];
                var col = currentBunnies[i + 1];

                if (IsInside(matrix, row - 1, col))
                {
                    matrix[row - 1, col] = 'B';
                }
                if (IsInside(matrix, row + 1, col))
                {
                    matrix[row + 1, col] = 'B';
                }
                if (IsInside(matrix, row, col + 1))
                {
                    matrix[row, col + 1] = 'B';
                }
                if (IsInside(matrix, row, col - 1))
                {
                    matrix[row, col - 1] = 'B';
                }
            }
            return matrix;
        }
        static void Print(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            var rowsAndCols = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            var rows = rowsAndCols[0];
            var cols = rowsAndCols[1];

            var lair = new char[rows, cols];
            var playerRow = 0;
            var playerCol = 0;

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    lair[row, col] = line[col];

                    if (line[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                        lair[row, col] = '.';
                    }
                }
            }
            var directions = Console.ReadLine();
            var currentBunnies = new List<int>();

            for (int i = 0; i < directions.Length; i++)
            {
                var currentDirection = directions[i];

                var currentSymbol = ' ';
                var isWon = false;

                if (currentDirection == 'L')
                {
                    if (IsInside(lair, playerRow, playerCol - 1))
                    {
                        currentSymbol = lair[playerRow, playerCol - 1];
                        playerCol -= 1;
                    }
                    else
                    {
                        isWon = true;
                    }
                }
                else if (currentDirection == 'R')
                {
                    if (IsInside(lair, playerRow, playerCol + 1))
                    {
                        currentSymbol = lair[playerRow, playerCol + 1];
                        playerCol += 1;
                    }
                    else
                    {
                        isWon = true;
                    }
                }
                else if (currentDirection == 'U')
                {
                    if (IsInside(lair, playerRow - 1, playerCol))
                    {
                        currentSymbol = lair[playerRow - 1, playerCol];
                        playerRow -= 1;
                    }
                    else
                    {
                        isWon = true;
                    }
                }
                else if (currentDirection == 'D')
                {
                    if (IsInside(lair, playerRow + 1, playerCol))
                    {
                        currentSymbol = lair[playerRow + 1, playerCol];
                        playerRow += 1;
                    }
                    else
                    {
                        isWon = true;
                    }
                }
                for (int row = 0; row < lair.GetLength(0); row++)
                {
                    for (int col = 0; col < lair.GetLength(1); col++)
                    {
                        if (lair[row, col] == 'B')
                        {
                            currentBunnies.Add(row);
                            currentBunnies.Add(col);
                        }
                    }
                }
                lair = BunnySpread(lair, currentBunnies);

                if (isWon)
                {
                    Print(lair);
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    break;
                }
                else if (currentSymbol == 'B')
                {
                    Print(lair);
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    break;
                }
                else
                {
                    if (lair[playerRow, playerCol] == 'B')
                    {
                        Print(lair);
                        Console.WriteLine($"dead: {playerRow} {playerCol}");
                        break;
                    }
                    else
                    {
                        currentBunnies = new List<int>();
                    }
                }
            }
        }
    }
}
