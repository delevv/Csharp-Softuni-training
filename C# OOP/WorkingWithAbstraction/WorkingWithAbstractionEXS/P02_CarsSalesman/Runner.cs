using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_CarsSalesman
{
    public static class Runner
    {
        public static void Run()
        {
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            int enginesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < enginesCount; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string engineModel = engineInfo[0];
                int power = int.Parse(engineInfo[1]);
                int displacement = -1;

                if (engineInfo.Length == 3 && int.TryParse(engineInfo[2], out displacement))
                {
                    engines.Add(new Engine(engineModel, power, displacement));
                }
                else if (engineInfo.Length == 3)
                {
                    string efficiency = engineInfo[2];
                    engines.Add(new Engine(engineModel, power, efficiency));
                }
                else if (engineInfo.Length == 4)
                {
                    string efficiency = engineInfo[3];
                    engines.Add(new Engine(engineModel, power, int.Parse(engineInfo[2]), efficiency));
                }
                else
                {
                    engines.Add(new Engine(engineModel, power));
                }
            }

            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] carInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                string engineModel = carInfo[1];
                Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);

                int weight = -1;

                if (carInfo.Length == 3 && int.TryParse(carInfo[2], out weight))
                {
                    cars.Add(new Car(model, engine, weight));
                }
                else if (carInfo.Length == 3)
                {
                    string color = carInfo[2];
                    cars.Add(new Car(model, engine, color));
                }
                else if (carInfo.Length == 4)
                {
                    string color = carInfo[3];
                    cars.Add(new Car(model, engine, int.Parse(carInfo[2]), color));
                }
                else
                {
                    cars.Add(new Car(model, engine));
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
