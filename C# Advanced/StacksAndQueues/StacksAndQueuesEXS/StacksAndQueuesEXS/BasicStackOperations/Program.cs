using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var info = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var elementsCount = info[0];
            var elementsToPop = info[1];
            var specialNumber = info[2];

            var stack = new Stack<int>();

            for (int i = 0; i < elementsCount; i++)
            {
                stack.Push(elements[i]);
            }
            for (int i = 0; i < elementsToPop; i++)
            {
                if (stack.Count != 0)
                {
                    stack.Pop();
                }
            }
            if (stack.Contains(specialNumber))
            {
                Console.WriteLine("true");
            }
            else if(stack.Count>0)
            {
                Console.WriteLine(stack.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
