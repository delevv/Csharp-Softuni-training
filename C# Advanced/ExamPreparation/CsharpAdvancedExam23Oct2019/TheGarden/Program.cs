using System;
using System.Collections.Generic;
using System.Linq;

namespace TheGarden
{
    class Program
    {
        static bool IsInside(char[][] garden, int row, int col)
        {
            return row >= 0 && row < garden.GetLength(0) && col >= 0 && col < garden[row].Length;
        }
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());

            var garden = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                garden[row] = new char[currentRow.Length];

                for (int col = 0; col < currentRow.Length; col++)
                {
                    garden[row][col] = currentRow[col];
                }
            }

            var harvesVegetables = new Dictionary<string, int>();

            harvesVegetables.Add("Lettuce", 0);
            harvesVegetables.Add("Potatoes", 0);
            harvesVegetables.Add("Carrots", 0);

            var harmedVegetablesCount = 0;

            var command = "";

            while ((command = Console.ReadLine()) != "End of Harvest")
            {
                var commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var action = commandArgs[0];
                var row = int.Parse(commandArgs[1]);
                var col = int.Parse(commandArgs[2]);

                if (action == "Harvest")
                {
                    if (IsInside(garden, row, col))
                    {
                        if (garden[row][col] == 'L')
                        {
                            harvesVegetables["Lettuce"]++;
                        }
                        else if (garden[row][col] == 'P')
                        {
                            harvesVegetables["Potatoes"]++;
                        }
                        else if (garden[row][col] == 'C')
                        {
                            harvesVegetables["Carrots"]++;
                        }

                        garden[row][col] = ' ';
                    }
                }
                else if (action == "Mole")
                {
                    var direction = commandArgs[3];

                    if (!IsInside(garden, row, col))
                    {
                        continue;
                    }
                    if (direction == "up")
                    {
                        for (int i = row; i >= 0; i -= 2)
                        {
                            if (garden[i][col] != ' ')
                            {
                                harmedVegetablesCount++;
                            }
                            garden[i][col] = ' ';
                        }
                    }
                    else if (direction == "down")
                    {
                        for (int i = row; i < garden.GetLength(0); i += 2)
                        {
                            if (garden[i][col] != ' ')
                            {
                                harmedVegetablesCount++;
                            }
                            garden[i][col] = ' ';
                        }
                    }
                    else if (direction == "left")
                    {
                        for (int i = col; i >= 0; i -= 2)
                        {
                            if (garden[row][i] != ' ')
                            {
                                harmedVegetablesCount++;
                            }
                            garden[row][i] = ' ';
                        }
                    }
                    else if (direction == "right")
                    {
                        for (int i = col; i < garden[row].Length; i += 2)
                        {
                            if (garden[row][i] != ' ')
                            {
                                harmedVegetablesCount++;
                            }
                            garden[row][i] = ' ';
                        }
                    }
                }
            }
            foreach (var row in garden)
            {
                Console.WriteLine(string.Join(" ", row));
            }

            Console.WriteLine($"Carrots: {harvesVegetables["Carrots"]}");
            Console.WriteLine($"Potatoes: {harvesVegetables["Potatoes"]}");
            Console.WriteLine($"Lettuce: {harvesVegetables["Lettuce"]}");

            Console.WriteLine($"Harmed vegetables: {harmedVegetablesCount}");
        }
    }
}
