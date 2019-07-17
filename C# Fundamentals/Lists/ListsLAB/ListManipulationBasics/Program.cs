using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                List<string> commandToList = command.Split().ToList();

                if (commandToList[0] == "Add")
                {
                    numbers.Add(int.Parse(commandToList[1]));
                }
                else if (commandToList[0] == "Remove")
                {
                    numbers.Remove(int.Parse(commandToList[1]));
                }
                else if (commandToList[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(commandToList[1]));
                }
                else if (commandToList[0] == "Insert")
                {
                    numbers.Insert(int.Parse(commandToList[2]), int.Parse(commandToList[1]));
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
