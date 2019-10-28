using System;
using System.Collections.Generic;
using System.Linq;

namespace DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var males = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var females = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            var matches = 0;

            while(males.Any() && females.Any())
            {
                var currentMale = males.Peek();
                var currentFemale = females.Peek();

                if (currentFemale % 25 == 0 && currentFemale!=0)
                {
                    females.Dequeue();
                    females.Dequeue();
                }
                else if(currentMale % 25 == 0 && currentMale!=0)
                {
                    males.Pop();
                    males.Pop();
                }
                else if (currentMale <= 0)
                {
                    males.Pop();
                }
                else if (currentFemale <= 0)
                {
                    females.Dequeue();
                }
                else if (currentFemale == currentMale)
                {
                    matches++;

                    males.Pop();
                    females.Dequeue();
                }
                else
                {
                    males.Pop();
                    females.Dequeue();
                    males.Push(currentMale - 2);
                }
            }
            Console.WriteLine($"Matches: {matches}");

            if (males.Any())
            {
                Console.WriteLine($"Males left: {string.Join(", ",males)}");
            }
            else
            {
                Console.WriteLine("Males left: none");
            }
            if (females.Any())
            {
                Console.WriteLine($"Females left: {string.Join(", ", females)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }
        }
    }
}
