using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsCount = int.Parse(Console.ReadLine());

            var jaggedArray = new double[rowsCount][];

            for (int row = 0; row < rowsCount; row++)
            {
                jaggedArray[row] = Console.ReadLine().Split().Select(double.Parse).ToArray();
            }

            for (int row = 0; row < rowsCount - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }
                    for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                    {
                        jaggedArray[row + 1][col] /= 2;
                    }
                }
            }
            var command = "";

            while ((command = Console.ReadLine()) != "End")
            {
                var commandArgs = command.Split();

                var action = commandArgs[0];
                var row = int.Parse(commandArgs[1]);
                var col = int.Parse(commandArgs[2]);
                var value = double.Parse(commandArgs[3]);

                if (row >= 0 && row < jaggedArray.GetLength(0) && col >= 0 && col < jaggedArray[row].Length)
                {
                    if (action == "Add")
                    {
                        jaggedArray[row][col] += value;
                    }
                    else if (action == "Subtract")
                    {
                        jaggedArray[row][col] -= value;
                    }
                }
            }
            foreach (var row in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
