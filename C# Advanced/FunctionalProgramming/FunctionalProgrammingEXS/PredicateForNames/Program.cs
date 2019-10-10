using System;
using System.Linq;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameLenght = int.Parse(Console.ReadLine());

            var names = Console.ReadLine().Split();

            Func<string, bool> nameFunc = name => name.Length <= nameLenght;

            names
                .Where(nameFunc)
                .ToList()
                .ForEach(name=>Console.WriteLine(name));    
        }
    }
}
