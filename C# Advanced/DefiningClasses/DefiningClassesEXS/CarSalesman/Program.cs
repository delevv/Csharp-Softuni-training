using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var engines = new List<Engine>();

            var countOfEngines = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfEngines; i++)
            {
                var engineInfo = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                var model = engineInfo[0];
                var power = int.Parse(engineInfo[1]);
                var displacement = 0;
                var efficiency = "";

                for (int j = 2; j < engineInfo.Length; j++)
                {
                    bool isDisplacement = int.TryParse(engineInfo[j], out int n);

                    if (isDisplacement)
                    {
                        displacement = n;
                    }
                    else
                    {
                        efficiency = engineInfo[j];
                    }
                }

                var engine = new Engine(model, power, displacement, efficiency);
                engines.Add(engine);
            }
            var countOfCars = int.Parse(Console.ReadLine());

            var cars = new List<Car>();

            for (int i = 0; i < countOfCars; i++)
            {
                var carInfo = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                var model = carInfo[0];
                var engineModel = carInfo[1];
                var weight = 0;
                var color = "";

                for (int j = 2; j < carInfo.Length; j++)
                {
                    bool isWeight = int.TryParse(carInfo[j], out int n);

                    if (isWeight)
                    {
                        weight = n;
                    }
                    else
                    {
                        color = carInfo[j];
                    }
                }
                var currentEngine = engines.FirstOrDefault(e=>e.Model==engineModel);

                var currentCar = new Car(model, currentEngine, weight, color);
                cars.Add(currentCar);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");

                if (car.Engine.Displacement == 0)
                {
                    Console.WriteLine($"    Displacement: n/a");
                }
                else
                {
                    Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                }

                if (car.Engine.Efficiency == "")
                {
                    Console.WriteLine($"    Efficiency: n/a");
                }
                else
                {
                    Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                }

                if (car.Weight == 0)
                {
                    Console.WriteLine($"  Weight: n/a");
                }
                else
                {
                    Console.WriteLine($"  Weight: {car.Weight}");
                }

                if (car.Color == "")
                {
                    Console.WriteLine($"  Color: n/a");
                }
                else
                {
                    Console.WriteLine($"  Color: {car.Color}");
                }
            }
        }
    }
}

