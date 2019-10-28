using System;
using System.Linq;

namespace Stack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var stack = new Stack<int>();

            var firstCommand = Console.ReadLine().Replace("Push ","").Split(", ").Select(int.Parse).ToArray();


            foreach (var item in firstCommand)
            {
                stack.Push(item);
            }

            var command = "";

            while ((command = Console.ReadLine()) != "END")
            {
                var commandArgs = command.Split();

                if (commandArgs[0] == "Pop")
                {
                    if (stack.Count() == 0)
                    {
                        Console.WriteLine("No elements");
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
                else if(commandArgs[0]=="Push")
                {
                    for (int i = 1; i < commandArgs.Length; i++)
                    {
                        stack.Push(int.Parse(commandArgs[i]));
                    }
                }
            }

            for (int i = 1; i <= 2; i++)
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
