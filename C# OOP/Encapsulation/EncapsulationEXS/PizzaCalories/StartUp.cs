using System;

namespace PizzaCalories
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                var pizzaName = Console.ReadLine().Split()[1];

                var doughInfo = Console.ReadLine().Split();

                var doughType = doughInfo[1];
                var technique = doughInfo[2];
                var doughWeight = double.Parse(doughInfo[3]);
                var dough = new Dough(doughType, technique, doughWeight);

                var pizza = new Pizza(pizzaName, dough);

                var command = "";

                while ((command = Console.ReadLine()) != "END")
                {
                    var toppingInfo = command.Split();

                    var toppingType = toppingInfo[1];
                    var toppingWeight = double.Parse(toppingInfo[2]);
                    var topping = new Topping(toppingType, toppingWeight);

                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
