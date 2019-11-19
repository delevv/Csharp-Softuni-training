namespace Vehicles
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            var carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var carFuel = double.Parse(carInfo[1]);
            var carConsumption = double.Parse(carInfo[2]);
            var carTankCapacity = double.Parse(carInfo[3]);

            var car = new Car(carFuel, carConsumption, carTankCapacity);

            var truckInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var truckFuel = double.Parse(truckInfo[1]);
            var truckConsumption = double.Parse(truckInfo[2]);
            var truckTankCapacity = double.Parse(truckInfo[3]);

            var truck = new Truck(truckFuel, truckConsumption, truckTankCapacity);

            var busInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var busFuel = double.Parse(busInfo[1]);
            var busConsumption = double.Parse(busInfo[2]);
            var busTankCapacity = double.Parse(busInfo[3]);

            var bus = new Bus(busFuel, busConsumption, busTankCapacity);

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
                    else if (vehicle == "Bus")
                    {
                        bus.IsEmpty = false;
                        Console.WriteLine(bus.Drive(distance));
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
                    else if (vehicle == "Bus")
                    {
                        bus.Refuel(liters);
                    }
                }
                else if (commandType == "DriveEmpty")
                {
                    var distance = double.Parse(commandArgs[2]);

                    bus.IsEmpty = true;
                    Console.WriteLine(bus.Drive(distance));
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
