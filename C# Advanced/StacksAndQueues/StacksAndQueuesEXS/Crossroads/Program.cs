using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            var greenLight = int.Parse(Console.ReadLine());
            var freeWindow = int.Parse(Console.ReadLine());

            var queue = new Queue<string>();
            var passedCars = 0;
            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "green")
                {
                    var green = greenLight;
                    var window = freeWindow;

                    while (green > 0)
                    {
                        if (queue.Count == 0)
                        {
                            break;
                        }
                            if (queue.Peek().Length <= green)
                            {
                                green -= queue.Dequeue().Length;
                                passedCars++;
                            }
                            else
                            {
                                var currentCar = queue.Dequeue();

                                for (int i = green; i < currentCar.Length; i++)
                                {
                                    window--;
                                    if (window < 0)
                                    {
                                        Console.WriteLine("A crash happened!");
                                        Console.WriteLine($"{currentCar} was hit at {currentCar[i]}.");
                                        return;
                                    }
                                }
                                passedCars++;
                                break;
                            }
                    }
                }
                else
                {
                    var carName = command;
                    queue.Enqueue(command);
                }
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }
    }
}
