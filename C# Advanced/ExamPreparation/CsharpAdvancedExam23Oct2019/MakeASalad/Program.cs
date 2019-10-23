using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MakeASalad
{
    class Program
    {
        static void Main(string[] args)
        {
            var vegetables = new Queue<string>(Console.ReadLine().Split());
            var calorieValues = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            var readySalads = new List<int>();
            var currentSalad = 0;

            while (vegetables.Any() && calorieValues.Any())
            {
                if (currentSalad <= 0)
                {
                    currentSalad = calorieValues.Peek();
                }
                var currentVegetable = vegetables.Dequeue();

                if (currentVegetable == "tomato")
                {
                    currentSalad -= 80;
                }
                else if (currentVegetable == "carrot")
                {
                    currentSalad -= 136;
                }
                else if (currentVegetable == "lettuce")
                {
                    currentSalad -= 109;
                }
                else if (currentVegetable == "potato")
                {
                    currentSalad -= 215;
                }

                if (currentSalad <= 0 )
                {
                    readySalads.Add(calorieValues.Pop());
                }
                if(currentSalad>=0 && vegetables.Count == 0 && calorieValues.Any())
                {
                    readySalads.Add(calorieValues.Pop());
                }
            }
            Console.WriteLine(string.Join(" ", readySalads));

            if (vegetables.Any())
            {
                Console.WriteLine(string.Join(" ", vegetables));
            }
            if (calorieValues.Any())
            {
                Console.WriteLine(string.Join(" ", calorieValues));
            }
        }
    }
}
