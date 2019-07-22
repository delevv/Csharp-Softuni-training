using System;
using System.Linq;

namespace SeizeTheFire
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fires = Console.ReadLine().Split(' ', '#').ToArray();
            
            int water = int.Parse(Console.ReadLine());
            int typeIndex = 0;
            int rangeIndex = 2;
            double effort = 0;
            int totalFire = 0;

            Console.WriteLine("Cells:");

            for (int i = 0; i < fires.Length; i += 3)
            {
                int fireRange = int.Parse(fires[rangeIndex + i]);
                string type = fires[typeIndex + i];
                if (type == "High")
                {
                    if (fireRange >= 81 && fireRange <= 125)
                    {
                        if (water >= fireRange)
                        {
                            water -= fireRange;
                            effort += fireRange * 0.25;
                            totalFire += fireRange;
                            Console.WriteLine($" - {fireRange}");
                        }
                    }
                }
                else if (type == "Medium")
                {
                    if (fireRange >= 51 && fireRange <= 80)
                    {
                        if (water >= fireRange)
                        {
                            water -= fireRange;
                            effort += fireRange * 0.25;
                            totalFire += fireRange;
                            Console.WriteLine($" - {fireRange}");
                        }
                    }
                }
                else if (type == "Low")
                {
                    if (fireRange >= 1 && fireRange <= 50)
                    {
                        if (water >= fireRange)
                        {
                            water -= fireRange;
                            effort += fireRange * 0.25;
                            totalFire += fireRange;
                            Console.WriteLine($" - {fireRange}");
                        }
                    }
                }
            }
            Console.WriteLine($"Effort: {effort:f2}");
            Console.WriteLine($"Total Fire: {totalFire}");
        }
    }
}
