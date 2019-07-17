using System;

namespace BeerKegs
{
    class Program
    {
        static void Main(string[] args)

        {
            int countOfKegs = int.Parse(Console.ReadLine());
            string biggestKeg = "";
            double biggestVolume = 0;
            for (int i = 0; i < countOfKegs; i++)
            {
                string model = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                double volume = Math.PI * Math.Pow(radius, 2) * height;
                if (biggestVolume < volume)
                {
                    biggestVolume = volume;
                    biggestKeg = model;
                }

            }
            Console.WriteLine(biggestKeg);

        }
    }
}
