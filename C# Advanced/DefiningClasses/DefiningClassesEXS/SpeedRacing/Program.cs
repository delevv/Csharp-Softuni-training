using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var countOfCars = int.Parse(Console.ReadLine());

            var cars = new List<Car>();


            for (int i = 0; i < countOfCars; i++)         
            {
                var carInfo = Console.ReadLine().Split();

                var carModel = carInfo[0];
                var fuelAmount = double.Parse(carInfo[1]);
                var fuelConsumption = double.Parse(carInfo[2]);

                var currentCar = new Car(carModel, fuelAmount, fuelConsumption);
                cars.Add(currentCar);
            }
            var command = "";

            while ((command = Console.ReadLine()) != "End")
            {
                var commandArgs = command.Split();

                var carModel = commandArgs[1];
                var distance = double.Parse(commandArgs[2]);

                foreach (var car in cars)
                {
                    if (car.Model == carModel)
                    {
                        car.Drive(distance);
                    }
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
