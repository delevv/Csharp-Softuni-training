using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            var cups = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var bottles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var bottlesStack = new Stack<int>(bottles);
            var cupsQueue = new Queue<int>(cups);
            var wastedWater = 0;

            var currentBottle = bottlesStack.Pop();

            while (true)
            {
                if (bottlesStack.Count ==0 && currentBottle==0)
                {
                    Console.WriteLine($"Cups: {string.Join(" ", cupsQueue)}");
                    break;
                }
                if (cupsQueue.Count == 0)
                {
                    Console.WriteLine($"Bottles: {string.Join(" ", bottlesStack)}");
                    break;
                }
                var currentCup = cupsQueue.Peek();

                while (currentCup > 0)
                {
                    if (currentCup - currentBottle <= 0)
                    {
                        cupsQueue.Dequeue();
                        wastedWater += currentBottle - currentCup;
                        currentCup = 0;
                        currentBottle = 0;
                    }
                    else
                    {
                        currentCup -= currentBottle;
                        currentBottle = 0;
                    }
                    if (bottlesStack.Count > 0 && cupsQueue.Count>0)
                    {
                        currentBottle = bottlesStack.Pop();
                    }
                }   
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
