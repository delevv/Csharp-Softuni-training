using System;

namespace SpringVacantionTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOfTrip = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int groupOfPeople = int.Parse(Console.ReadLine());
            double fuelPricePerKm = double.Parse(Console.ReadLine());
            double foodPricePerPerson = double.Parse(Console.ReadLine());
            double roomPricePerPerson = double.Parse(Console.ReadLine());

            double totalFoodPrice = daysOfTrip * groupOfPeople * foodPricePerPerson;
            double totalHotelPrice = daysOfTrip * groupOfPeople * roomPricePerPerson;

            if (groupOfPeople > 10) totalHotelPrice -= totalHotelPrice * 0.25;

            double totalPrice = totalHotelPrice + totalFoodPrice;

            for (int i = 1; i <= daysOfTrip; i++)
            {
                double distance = double.Parse(Console.ReadLine());

                double fuelPricePerDay = distance * fuelPricePerKm;
                totalPrice += fuelPricePerDay;

                if (i % 3 == 0 || i % 5 == 0)
                {
                    totalPrice += totalPrice * 0.4;
                }
                if (i % 7 == 0)
                {
                    totalPrice -= totalPrice / groupOfPeople;
                }
                if (totalPrice > budget)
                {
                    Console.WriteLine($"Not enough money to continue the trip. You need {totalPrice-budget:f2}$ more.");
                    break;
                }
            }
            if (totalPrice <= budget)
            {
                Console.WriteLine($"You have reached the destination. You have {budget-totalPrice:f2}$ budget left.");
            }
        }
    }
}
