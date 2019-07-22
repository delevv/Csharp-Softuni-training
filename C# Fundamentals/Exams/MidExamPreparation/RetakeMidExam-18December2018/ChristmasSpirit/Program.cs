using System;

namespace ChristmasSpirit
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int ornamentSet = 2;
            int treeSkirt = 5;
            int treeGirlands = 3;
            int treeLights = 15;

            double totalPrice = 0;
            int totalSpirit = 0;

            for (int i = 1; i <= days; i++)
            {
                if (i % 11 == 0)
                {
                    quantity += 2;
                }
                if (i % 2 == 0)
                {
                    totalPrice += ornamentSet * quantity;
                    totalSpirit += 5;
                }
                if (i % 3 == 0)
                {
                    totalPrice += treeGirlands * quantity;
                    totalPrice += treeSkirt * quantity;
                    totalSpirit += 13;
                }
                if (i % 5 == 0)
                {
                    totalPrice += quantity * treeLights;
                    totalSpirit += 17;
                    if (i % 3 == 0)
                    {
                        totalSpirit += 30;
                    }
                }
                if (i % 10 == 0)
                {
                    totalSpirit -= 20;
                    totalPrice += treeGirlands + treeSkirt + treeLights;
                    if (i == days)
                    {
                        totalSpirit -= 30;
                    }
                }
            }

            Console.WriteLine($"Total cost: {totalPrice}");
            Console.WriteLine($"Total spirit: {totalSpirit}");
        }
    }
}
