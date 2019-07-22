using System;

namespace EasternsCozonacs
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double floorPriceForKg = double.Parse(Console.ReadLine());
            double eggsPriceForPack = floorPriceForKg * 0.75;
            double milkPriceForLiter = floorPriceForKg + (floorPriceForKg * 0.25);
            double milkPriceFor250ml = milkPriceForLiter / 4;

            double priceForOneCozonacs = eggsPriceForPack + floorPriceForKg + milkPriceFor250ml;
            int cozonacsCount = 0;
            int coloredEggs = 0;

            while (budget > priceForOneCozonacs)
            {
                budget -= priceForOneCozonacs;
                cozonacsCount++;
                coloredEggs += 3;
                if (cozonacsCount % 3 == 0)
                {
                    coloredEggs -= cozonacsCount - 2;
                }
            }
            Console.WriteLine($"You made {cozonacsCount} cozonacs! Now you have {coloredEggs} eggs and {budget:f2}BGN left.");
        }
    }
}
