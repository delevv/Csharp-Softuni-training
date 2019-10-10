using System;
using System.Linq;
using System.Collections.Generic;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = name => Console.WriteLine("Sir " + name);

            Console.ReadLine()
                .Split()
                .ToList()
                .ForEach(x => print(x));
        }
    }
}
