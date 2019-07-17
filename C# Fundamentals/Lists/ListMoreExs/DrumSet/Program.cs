using System;
using System.Collections.Generic;
using System.Linq;

namespace DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());

            List<int> drumSet = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> copyDrumSet = new List<int>(drumSet);

            string command;
            while((command=Console.ReadLine())!="Hit it again, Gabsy!")
            {
                int power = int.Parse(command);

                for (int i = 0; i < copyDrumSet.Count; i++)
                {
                    if (copyDrumSet[i] - power > 0)
                    {
                        copyDrumSet[i] -= power;
                    }
                    else
                    {
                        if (savings - drumSet[i] * 3 >= 0)
                        {
                            copyDrumSet[i] = drumSet[i];
                            savings -= drumSet[i] * 3;
                        }
                        else
                        {
                            copyDrumSet.RemoveAt(i);
                            drumSet.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ",copyDrumSet));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
