using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcelFunctions
{
    public class Program
    {
        static void HideColAndPrint(string[][] table, int headerColIndex)
        {
            for (int row = 0; row < table.Length; row++)
            {
                List<string> lineToPrint = new List<string>(table[row]);

                lineToPrint.RemoveAt(headerColIndex);
                Console.WriteLine(string.Join(" | ", lineToPrint));

                table[row] = lineToPrint.ToArray();
            }
        }
        static void Print(string[][] table)
        {
            for (int row = 0; row < table.GetLength(0); row++)
            {
                for (int col = 0; col < table[row].Length; col++)
                {
                    Console.Write(table[row][col]);

                    if (col != table[row].Length - 1)
                    {
                        Console.Write(" | ");
                    }
                }
                Console.WriteLine();
            }
        }
        public static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());

            var table = new string[rows][];

            for (int row = 0; row < rows; row++)
            {
                table[row] = Console.ReadLine().Split(", ");
            }

            var commandInfo = Console.ReadLine().Split();

            var action = commandInfo[0];
            var headerName = commandInfo[1];

            var headerColIndex = 0;

            for (int col = 0; col < table[0].Length; col++)
            {
                if (headerName == table[0][col])
                {
                    headerColIndex = col;
                }
            }

            if (action == "hide")
            {
                HideColAndPrint(table, headerColIndex);
            }
            else if (action == "sort")
            {
                Console.WriteLine(string.Join(" | ", table[0]));

                table = table.Skip(1).OrderBy(x => x[headerColIndex]).ToArray();

                Print(table);
            }
            else if (action == "filter")
            {
                string parameter = commandInfo[2];
                string[] headerRow = table[0];

                Console.WriteLine(string.Join(" | ", headerRow));

                for (int i = 0; i < table.Length; i++)
                {
                    if (table[i][headerColIndex] == parameter)
                    {
                        Console.WriteLine(string.Join(" | ", table[i]));
                    }
                }
            }
        }
    }
}
