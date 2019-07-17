using System;

namespace Exs1
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepsMade = int.Parse(Console.ReadLine());
            double lenghtOfStep = double.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            double distanceMade = 0;

            for (int i = 1; i <= stepsMade; i++)
            {
                if (i % 5 == 0)
                {
                    distanceMade+=lenghtOfStep - lenghtOfStep * 0.30;
                }
                else
                {
                    distanceMade += lenghtOfStep;
                }
            }

            double percentage =(distanceMade/distance*1.00);

            Console.WriteLine($"You travelled {percentage:f2}% of the distance!");
        }
    }
}
