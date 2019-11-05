using System;

namespace P05_GreedyTimes
{
    public static class Engine
    {
        public static void Run()
        {
            var bagCapacity = long.Parse(Console.ReadLine());

            var bag = new Bag(bagCapacity);

            var itemsAndQuantity = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < itemsAndQuantity.Length-1; i += 2)
            {
                var currentItem = itemsAndQuantity[i];
                var currentItemQuantity = long.Parse(itemsAndQuantity[i + 1]);

                bag.AddItem(currentItem, currentItemQuantity);
            }
            if (bag.currentCapacity > 0)
            {
                Console.WriteLine(bag);
            }
        }
    }
}
