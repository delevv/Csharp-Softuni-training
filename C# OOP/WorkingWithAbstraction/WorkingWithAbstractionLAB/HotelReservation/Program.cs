using System;

namespace HotelReservation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var reservationInfo = Console.ReadLine().Split();

            var pricePerDay = decimal.Parse(reservationInfo[0]);
            var numberOfDays = int.Parse(reservationInfo[1]);
            var seasonString =reservationInfo[2];

            var discountString = "";
            if (reservationInfo.Length == 4)
            {
                discountString = reservationInfo[3];
            }

            Season season=Season.Summer;

            if (seasonString == Season.Autumn.ToString())
            {
                season = Season.Autumn;
            }
            else if (seasonString == Season.Spring.ToString())
            {
                season = Season.Spring;
            }
            else if (seasonString == Season.Winter.ToString())
            {
                season = Season.Winter;
            }
            else if (seasonString == Season.Summer.ToString())
            {
                season = Season.Summer;
            }

            Discount discountType=Discount.None;

            if (discountString == Discount.None.ToString())
            {
                discountType = Discount.None;
            }
            else if (discountString == Discount.SecondVisit.ToString())
            {
                discountType = Discount.SecondVisit;
            }
            else if (discountString == Discount.VIP.ToString())
            {
                discountType = Discount.VIP;
            }
           
            var finalPrice=PriceCalculator.CalculatePrice(pricePerDay, numberOfDays, season, discountType);

            Console.WriteLine($"{finalPrice:f2}");
        }
    }
}
