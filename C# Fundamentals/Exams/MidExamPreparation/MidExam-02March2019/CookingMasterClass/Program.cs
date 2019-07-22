using System;

namespace CookingMasterClass
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double flourPrice = double.Parse(Console.ReadLine());
            double eggPrice = double.Parse(Console.ReadLine());
            double apronPrice = double.Parse(Console.ReadLine());

            double totalPrice = apronPrice * (students + Math.Ceiling(students * 0.2)) + eggPrice * 10 * students + flourPrice * (students -students / 5);

            if (totalPrice <= budget)
            {
                Console.WriteLine($"Items purchased for {totalPrice:f2}$.");
            }
            else
            {
                Console.WriteLine($"{totalPrice-budget:f2}$ more needed.");
            }
        }
    }
}
