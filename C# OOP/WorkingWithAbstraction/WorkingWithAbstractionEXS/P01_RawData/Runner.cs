using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    public static class Runner
    {
        public static void Run()
        {
            int countOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();


            for (int i = 0; i < countOfCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string carModel = carInfo[0];

                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                var engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];
                var cargo = new Cargo(cargoWeight, cargoType);

                var tires = new Tire[4];

                double firstTirePressure = double.Parse(carInfo[5]);
                int firstTireAge = int.Parse(carInfo[6]);
                tires[0] = new Tire(firstTireAge, firstTirePressure);

                double secondTirePressure = double.Parse(carInfo[7]);
                int secondTireAge = int.Parse(carInfo[8]);
                tires[1] = new Tire(secondTireAge, secondTirePressure);

                double thirdTirePressure = double.Parse(carInfo[9]);
                int thirdTireAge = int.Parse(carInfo[10]);
                tires[2] = new Tire(thirdTireAge, thirdTirePressure);

                double fourthTirePressure = double.Parse(carInfo[11]);
                int fourthTireAge = int.Parse(carInfo[12]);
                tires[3] = new Tire(fourthTireAge, fourthTirePressure);

                cars.Add(new Car(carModel, engine, cargo, tires));
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }
    }
}
