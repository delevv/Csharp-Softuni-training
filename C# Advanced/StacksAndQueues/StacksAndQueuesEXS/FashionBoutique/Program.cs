using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var clothesInBox = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rackCapacity = int.Parse(Console.ReadLine());

            var stack = new Stack<int>(clothesInBox);
            var rackCount = 1;
            var currentRack = rackCapacity;

            while (stack.Count > 0)
            {
                var currentClothes = stack.Peek();

                if (currentClothes <= currentRack)
                {
                    currentRack -= stack.Pop();
                }
                else
                {
                    rackCount++;
                    currentRack = rackCapacity;
                }
            }
            Console.WriteLine(rackCount);
        }
    }
}
