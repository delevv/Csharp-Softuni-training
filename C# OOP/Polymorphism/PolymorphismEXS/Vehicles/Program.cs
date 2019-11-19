namespace Vehicles
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            var carInfo = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            
            var carFuel = double.Parse(carInfo[1]);
            var carConsumption = double.Parse(carInfo[2]);

            var car = new Car(carFuel, carConsumption);
            
            var truckInfo= Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var truckFuel = double.Parse(truckInfo[1]);
            var truckConsumption = double.Parse(truckInfo[2]);

            var truck = new Truck(truckFuel, truckConsumption);

            var commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                var commandArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var commandType = commandArgs[0];
                var vehicle = commandArgs[1];

                if (commandType == "Drive")
                {
                    var distance = double.Parse(commandArgs[2]);

                    if (vehicle == "Car")
                    {
                        Console.WriteLine(car.Drive(distance));
                    }
                    else if (vehicle == "Truck")
                    {
                        Console.WriteLine(truck.Drive(distance));
                    }
                }
                else if (commandType == "Refuel")
                {
                    var liters = double.Parse(commandArgs[2]);

                    if (vehicle == "Car")
                    {
                        car.Refuel(liters);
                    }
                    else if (vehicle == "Truck")
                    {
                        truck.Refuel(liters);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
