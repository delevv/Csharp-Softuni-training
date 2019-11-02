using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
   public static class PriceCalculator
    {
        public static decimal CalculatePrice(decimal pricePerDay, int numberOfDays, Season season, Discount discount)
        {
            var multiplier = (int)season;
            var discountMultiplier = (decimal)discount / 100;
            var priceBeforeDiscount = numberOfDays * pricePerDay * multiplier;
            var discountedAmount = priceBeforeDiscount * discountMultiplier;
            var finalPrice = priceBeforeDiscount - discountedAmount;

            return finalPrice;
        }
    }
}
