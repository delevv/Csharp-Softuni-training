using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
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

                var model = carInfo[0];

                var engineSpeed = int.Parse(carInfo[1]);
                var enginePower = int.Parse(carInfo[2]);
                var engine = new Engine(engineSpeed, enginePower);

                var cargoWeight = int.Parse(carInfo[3]);
                var cargoType = carInfo[4];
                var cargo = new Cargo(cargoWeight, cargoType);

                var tires = new List<Tire>();

                for (int j = 5; j < carInfo.Length; j += 2)
                {
                    var tirePressure = double.Parse(carInfo[j]);
                    var tireAge = int.Parse(carInfo[j + 1]);

                    tires.Add(new Tire(tireAge, tirePressure));
                }

                var currentCar = new Car(model, engine, cargo, tires);
                cars.Add(currentCar);
            }

            var sepcialCargoType = Console.ReadLine();

            if (sepcialCargoType == "fragile")
            {
                cars
                    .Where(car => car.Cargo.Type == "fragile" && car.Tires.Any(tire => tire.Pressure < 1))
                    .ToList()
                    .ForEach(car => Console.WriteLine(car.Model));
            }
            else
            {
                cars
                 .Where(car => car.Cargo.Type == "flamable" && car.Engine.Power > 250)
                 .ToList()
                 .ForEach(car => Console.WriteLine(car.Model));
            }
        }
    }
}
