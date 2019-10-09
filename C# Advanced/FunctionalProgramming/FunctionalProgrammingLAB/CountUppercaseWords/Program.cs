using System;
using System.Linq;

namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                  .Where(x => char.IsUpper(x[0]));

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
