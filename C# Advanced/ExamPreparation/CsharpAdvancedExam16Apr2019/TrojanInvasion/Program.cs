using System;
using System.Collections.Generic;
using System.Linq;

namespace TrojanInvasion
{
    class Program
    {
        static void Main(string[] args)
        {
            var wavesCount = int.Parse(Console.ReadLine());
            var plates = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            for (int i = 1; i <= wavesCount; i++)
            {
                var currentWave = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

                if (i % 3 == 0)
                {
                    plates.Enqueue(int.Parse(Console.ReadLine()));
                }

                while (currentWave.Count > 0 && plates.Count > 0)
                {
                    var currentWarrior = currentWave.Peek();
                    var currentPlate = plates.Peek();

                    if (currentPlate - currentWarrior > 0)
                    {
                        plates.Dequeue();
                        plates=new Queue<int>(plates.Reverse());
                        plates.Enqueue(currentPlate - currentWarrior);
                        plates = new Queue<int>(plates.Reverse());

                        currentWave.Pop();
                    }
                    else if (currentPlate - currentWarrior < 0)
                    {
                        currentWave.Pop();
                        currentWave.Push(currentWarrior - currentPlate);
                        plates.Dequeue();
                    }
                    else
                    {
                        plates.Dequeue();
                        currentWave.Pop();
                    }
                }
                if (plates.Count == 0)
                {
                    Console.WriteLine($"The Trojans successfully destroyed the Spartan defense.");
                    Console.WriteLine($"Warriors left: {string.Join(", ", currentWave)}");
                    break;
                }
            }
            if (plates.Count != 0)
            {
                Console.WriteLine($"The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}
