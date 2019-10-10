using System;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToList();

            var divideNumber = int.Parse(Console.ReadLine());

            Func<int, bool> divideFunc = num => num % divideNumber == 0;

            numbers = numbers
                .Where(x => !divideFunc(x))
                .ToList();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
