using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var stack = new Stack<int>(numbers);
            var command = "";

            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                var commandArgs = command.Split();

                if (commandArgs[0] == "add")
                {
                    stack.Push(int.Parse(commandArgs[1]));
                    stack.Push(int.Parse(commandArgs[2]));
                }
                else if (commandArgs[0] == "remove")
                {
                    var count = int.Parse(commandArgs[1]);

                    if (count <= stack.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
