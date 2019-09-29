using System;
using System.Linq;

namespace JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());

            var jaggedArray = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                jaggedArray[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            var command="";

            while ((command = Console.ReadLine()) != "END")
            {
                var commandArgs = command.Split();
                var action = commandArgs[0];
                var row = int.Parse(commandArgs[1]);
                var col = int.Parse(commandArgs[2]);
                var value = int.Parse(commandArgs[3]);

                if (row >= jaggedArray.Length || row<0 || (col < 0 || col >= jaggedArray[row].Length))
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else if (action == "Add")
                {
                    jaggedArray[row][col] += value;
                }
                else
                {
                    jaggedArray[row][col] -= value;

                }
            }
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                Console.WriteLine(string.Join(" ",jaggedArray[row]));
            }
        }
    }
}
