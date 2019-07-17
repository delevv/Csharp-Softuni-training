using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogue
{
    class Catalogue
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower{ get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Catalogue> catalogue = new List<Catalogue>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] vehicleInfo = input.Split();

                Catalogue newVehicle = new Catalogue();
                newVehicle.Type = vehicleInfo[0];
                newVehicle.Model = vehicleInfo[1];
                newVehicle.Color = vehicleInfo[2];
                newVehicle.HorsePower = int.Parse(vehicleInfo[3]);
                catalogue.Add(newVehicle);
            }
            while ((input = Console.ReadLine()) != "Close the Catalogue")
            {
                foreach (var vehicle in catalogue)
                {
                    if (vehicle.Model == input)
                    {
                        if (vehicle.Type == "car") vehicle.Type = "Car";
                        else if (vehicle.Type == "truck") vehicle.Type = "Truck";

                        Console.WriteLine($"Type: {vehicle.Type}");
                        Console.WriteLine($"Model: {vehicle.Model}");
                        Console.WriteLine($"Color: {vehicle.Color}");
                        Console.WriteLine($"Horsepower: {vehicle.HorsePower}");
                    }
                }
            }

            int truckCount = 0;
            int truckSum = 0;
            int carCount = 0;
            int carSum = 0;

            foreach (var vehicle in catalogue)
            {
                if (vehicle.Type == "Truck" || vehicle.Type == "truck")
                {
                    truckCount++;
                    truckSum += vehicle.HorsePower;
                }
                else if (vehicle.Type == "Car" || vehicle.Type=="car")
                {
                    carCount++;
                    carSum += vehicle.HorsePower;
                }
            }

            double truckAvg = truckSum * 1.00 / truckCount;
            double carAvg = carSum * 1.00 / carCount;

            if (carAvg > 1)
            {
                Console.WriteLine($"Cars have average horsepower of: {carAvg:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: 0.00.");
            }
            if (truckAvg > 1)
            {
                Console.WriteLine($"Trucks have average horsepower of: {truckAvg:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: 0.00.");
            }
        }
    }
}
