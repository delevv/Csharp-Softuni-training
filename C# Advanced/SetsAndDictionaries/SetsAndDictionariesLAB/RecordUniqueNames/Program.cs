using System;
using System.Collections.Generic;
using System.Linq;

namespace RecordUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var countOfNames = int.Parse(Console.ReadLine());

            var names = new HashSet<string>();

            for (int i = 0; i < countOfNames; i++)
            {
                names.Add(Console.ReadLine());
            }
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
