using System;
using System.Linq;

namespace SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                 .Split(", ")
                 .Select(int.Parse)
                 .Where(x => x % 2 == 0)
                 .OrderBy(x => x);

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
