using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var expression = Console.ReadLine().Split().ToArray().Reverse();

            var stack = new Stack<string>(expression);
            var result = 0;

            while (stack.Count > 0)
            {
                if (stack.Peek()=="+")
                {
                    stack.Pop();
                    result += int.Parse(stack.Pop());
                }
                else if (stack.Peek() == "-")
                {
                    stack.Pop();
                    result -= int.Parse(stack.Pop());
                }
                else
                {
                    result += int.Parse(stack.Pop());
                }
            }
            Console.WriteLine(result);
        }
    }
}
