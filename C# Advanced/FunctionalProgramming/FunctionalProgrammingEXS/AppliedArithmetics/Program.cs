using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Func<int, int> addFunc = num => num += 1;
            Func<int, int> multiplyFunc = num => num *= 2;
            Func<int, int> suntractFunc = num => num -= 1;

            var command = "";

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "add")
                {
                    numbers = numbers.Select(addFunc).ToList();
                }
                else if (command == "multiply")
                {
                    numbers = numbers.Select(multiplyFunc).ToList();

                }
                else if (command == "subtract")
                {
                    numbers = numbers.Select(suntractFunc).ToList();

                }
                else if (command == "print")
                {
                    Console.WriteLine(string.Join(" ",numbers));
                }
            }
        }
    }
}
