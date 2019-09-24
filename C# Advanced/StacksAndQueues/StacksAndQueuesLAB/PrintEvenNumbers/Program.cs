using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {   
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var stack = new Queue<int>();

            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    stack.Enqueue(number);
                }
            }
            Console.WriteLine(string.Join(", ",stack));
        }
    }
}
