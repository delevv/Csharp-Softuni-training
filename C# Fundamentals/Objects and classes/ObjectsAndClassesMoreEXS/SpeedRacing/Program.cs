using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsum { get; set; }
        public double TraveledDistace { get; set; }

    }
    class Program
    {
        static void EnoughFuelOrNot(List<Car> cars, string model, double amountOfKm)
        {
            foreach (var car in cars)
            {
                if (car.Model == model)
                {
                    if (car.FuelAmount - amountOfKm * car.FuelConsum >= 0)
                    {
                        car.FuelAmount -= amountOfKm * car.FuelConsum;
                        car.TraveledDistace += amountOfKm;
                    }
                    else
                    {
                        Console.WriteLine("Insufficient fuel for the drive");
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < count; i++)
            {
                string[] carInfo = Console.ReadLine().Split();
                Car car = new Car();

                car.Model = carInfo[0];
                car.FuelAmount = double.Parse(carInfo[1]);
                car.FuelConsum = double.Parse(carInfo[2]);
                car.TraveledDistace = 0;
                cars.Add(car);
                
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] carInstruction = command.Split();

                string model = carInstruction[1];
                double amountOfKm = double.Parse(carInstruction[2]);

                EnoughFuelOrNot(cars, model, amountOfKm);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistace}");
            }
        }
    }
}
