using System;
using System.Collections.Generic;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            var carNumbers = new HashSet<string>();

            var command = "";

            while ((command = Console.ReadLine()) != "END")
            {
                var currentCar = command.Split(", ");

                var direction = currentCar[0];
                var number = currentCar[1];

                if (direction == "IN")
                {
                    carNumbers.Add(number);
                }
                else
                {
                    carNumbers.Remove(number);
                }
            }
            if(carNumbers.Count>0  )
            {
                foreach (var number in carNumbers)
                {
                    Console.WriteLine(number);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
