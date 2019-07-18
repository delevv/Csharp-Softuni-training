using System;
using System.Collections.Generic;
using System.Linq;

namespace OddOccurences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().Select(x=>x=x.ToLower()).ToArray();

            var dict = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!dict.ContainsKey(word))
                {
                    dict[word] = 0;
                }
                dict[word]++;
            }
            foreach (var item in dict)
            {
                if (item.Value % 2 == 1)
                {
                    Console.Write(item.Key+ " ");
                }
            }

        }
    }
}
