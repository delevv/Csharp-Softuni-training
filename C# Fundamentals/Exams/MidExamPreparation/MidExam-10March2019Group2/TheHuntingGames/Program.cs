using System;

namespace TheHuntingGames
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysCount = int.Parse(Console.ReadLine());
            int playersCount = int.Parse(Console.ReadLine());
            double groupEnergy = double.Parse(Console.ReadLine());
            double waterPerDayForPerson = double.Parse(Console.ReadLine());
            double foodPerDayForPerson = double.Parse(Console.ReadLine());

            double totalWater = waterPerDayForPerson * playersCount * daysCount;
            double totalFood = foodPerDayForPerson * playersCount * daysCount;

            for (int currentDay = 1; currentDay <= daysCount; currentDay++)
            {
                double energyLoss = double.Parse(Console.ReadLine());
                groupEnergy -= energyLoss;
                if (groupEnergy <= 0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water.");
                    break;
                }
                if (currentDay % 2 == 0)
                {
                    groupEnergy += groupEnergy * 0.05;
                    totalWater -= totalWater * 0.30;
                }
                if (currentDay % 3 == 0)
                {
                    groupEnergy += groupEnergy * 0.10;
                    totalFood -= totalFood / playersCount;
                }
                if (currentDay == daysCount)
                {
                    Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:f2} energy!");
                }
            }   
        }
    }
}
