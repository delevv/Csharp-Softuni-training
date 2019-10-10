using System;
using System.Linq;

namespace ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = name => Console.WriteLine(name);

            Console.ReadLine()
                .Split()
                .ToList()
                .ForEach(x => print(x));
        }
    }
}
