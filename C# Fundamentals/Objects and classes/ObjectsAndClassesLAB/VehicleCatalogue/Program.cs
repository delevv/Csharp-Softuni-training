using System;
using System.Collections.Generic;
using System.Linq;
namespace VehicleCatalogue
{
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Weight { get; set; }
    }
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Power { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Truck> trucks = new List<Truck>();
            List<Car> cars = new List<Car>();

           string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] info = command.Split("/");

                string type = info[0];
                string brand = info[1];
                string model = info[2];

                if (type == "Truck")
                {
                    string weight = info[3];

                    Truck truck = new Truck();
                    truck.Brand = brand;
                    truck.Model = model;
                    truck.Weight = weight;
                    trucks.Add(truck);
                }
                else if (type == "Car")
                {
                    string power = info[3];

                    Car car = new Car();
                    car.Brand = brand;
                    car.Model = model;
                    car.Power = power;
                    cars.Add(car);
                }
            }

            List<Car> sortedCars = cars.OrderBy(c=>c.Brand).ToList();
            List<Truck> sortedTrucks = trucks.OrderBy(t=>t.Brand).ToList();

            if (cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (var car in sortedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.Power}hp");
                }
            }
            if (trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (var truck in sortedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
            
        }
    }
}
