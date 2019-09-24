using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            var queries = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            for (int i = 0; i < queries; i++)
            {
                var command = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var action = command[0];

                if (action == 1)
                {
                    var element = command[1];
                    stack.Push(element);
                }
                else if (action == 2)
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else if (action == 3)
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Max());
                    }
                }
                else if (action == 4)
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }
            Console.WriteLine(string.Join(", ",stack));
        }
    }
}
