using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            var operationsCount = int.Parse(Console.ReadLine());
            var text = new StringBuilder();
            var stack = new Stack<string>();

            for (int i = 0; i < operationsCount; i++)
            {
                var commandArgs = Console.ReadLine().Split();
                var action = int.Parse(commandArgs[0]);
                var lastText = text.ToString();

                switch (action)
                {
                    case 1:
                        stack.Push(lastText);
                        text.Append(commandArgs[1]);
                        break;
                    case 2:
                        var count = int.Parse(commandArgs[1]);
                        stack.Push(lastText);
                        text.Remove(text.Length - count, count);
                        break;
                    case 3:
                        var index = int.Parse(commandArgs[1]);
                        Console.WriteLine(text[index - 1]);
                        break;
                    case 4:
                        text.Clear();
                        text.Append(stack.Pop());
                        break;
                }
            }
        }
    }
}
