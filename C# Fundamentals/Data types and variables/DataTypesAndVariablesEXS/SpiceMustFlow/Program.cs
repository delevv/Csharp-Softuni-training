using System;

namespace SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startYield = int.Parse(Console.ReadLine());
            int totalAmount = 0;
            int daysCount = 0;
           if(startYield>=100)
            { 
                while (startYield >= 100)
                {
                    daysCount++;
                    totalAmount += startYield - 26;
                    startYield -= 10;
                }
                totalAmount -= 26;
            }
            Console.WriteLine(daysCount);
            Console.WriteLine(totalAmount);

        }
    }
}
