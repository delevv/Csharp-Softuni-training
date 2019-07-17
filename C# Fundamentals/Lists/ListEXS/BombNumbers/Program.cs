using System;
using System.Collections.Generic;
using System.Linq;

namespace BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> magicNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int special = magicNumbers[0];
            int power = magicNumbers[1];

            while (numbers.Contains(special))
            {
                for (int i = 0; i < power; i++)
                {
                    int specialIndex = numbers.IndexOf(special);
                    if (specialIndex-1>=0 && specialIndex - 1 < numbers.Count)
                    {
                        numbers.RemoveAt(specialIndex - 1);
                    }
                }
                for (int i = 0; i < power; i++)
                {
                    int specialIndex = numbers.IndexOf(special);
                    if (specialIndex +1 >= 0 && specialIndex + 1 < numbers.Count)
                    {
                        numbers.RemoveAt(specialIndex + 1);
                    }
                }
                numbers.Remove(special);
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
