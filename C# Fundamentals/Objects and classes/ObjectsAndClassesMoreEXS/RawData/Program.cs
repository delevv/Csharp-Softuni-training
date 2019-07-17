using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class Car
    {
        public string Model { get; set; }
        public Engine Engine{get; set;}
        public Cargo Cargo{get; set;}

        public Car(string model,Engine engine,Cargo cargo)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
        }
    }
    class Engine
    {
        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }
    }
    class Cargo
    {
        public int CargoWeigth { get; set; }
        public string CargoType { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < count; i++)
            {
                string[] carInfo = Console.ReadLine().Split();

                string model = carInfo[0];
                
                Engine currentEngine = new Engine();
                currentEngine.EngineSpeed = int.Parse(carInfo[1]);
                currentEngine.EnginePower = int.Parse(carInfo[2]);

                Cargo currentCargo = new Cargo();
                currentCargo.CargoWeigth = int.Parse(carInfo[3]);
                currentCargo.CargoType = carInfo[4];

                Car currentCar = new Car(model,currentEngine,currentCargo);
                cars.Add(currentCar);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in cars)
                {
                    if(car.Cargo.CargoType=="fragile" && car.Cargo.CargoWeigth < 1000)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
            else if (command == "flamable")
            {
                foreach (var car in cars)
                {
                    if (car.Cargo.CargoType == "flamable" && car.Engine.EnginePower > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }
    }
}
