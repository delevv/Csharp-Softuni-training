using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var tires = new List<Tire[]>();

            var command = "";

            while ((command = Console.ReadLine()) != "No more tires")
            {

                var currentTires = command.Split();
                var tire = new Tire[4];
                var tireIndex = 0;

                for (int i = 0; i < currentTires.Length - 1; i += 2)
                {
                    var year = int.Parse(currentTires[i]);
                    var pressure = double.Parse(currentTires[i + 1]);

                    tire[tireIndex] = new Tire(year, pressure);
                    tireIndex++;
                }
                tires.Add(tire);
            }

            var engines = new List<Engine>();

            while ((command = Console.ReadLine()) != "Engines done")
            {
                var currentEngine = command.Split();

                var horsePower = int.Parse(currentEngine[0]);
                var cubicCapacity = double.Parse(currentEngine[1]);

                engines.Add(new Engine(horsePower, cubicCapacity));
            }

            var cars = new List<Car>();

            while ((command = Console.ReadLine()) != "Show special")
            {
                var carInfo = command.Split();

                var make = carInfo[0];
                var model = carInfo[1];
                var year = int.Parse(carInfo[2]);
                var fuelQuantity = double.Parse(carInfo[3]);
                var fuelConsumption = double.Parse(carInfo[4]);
                var engineIndex = int.Parse(carInfo[5]);
                var tiresIndex = int.Parse(carInfo[6]);

                var currentCar = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);
                cars.Add(currentCar);
            }

            cars = cars
                  .Where(car => car.Year >= 2017
                  && car.Engine.HorsePower > 330
                  && car.Tires.Sum(x => x.Pressure) >= 9
                  && car.Tires.Sum(x => x.Pressure) <= 10)
                  .ToList();

            foreach (var car in cars)
            {
                car.Drive(20);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
            }
        }
    }   
}

