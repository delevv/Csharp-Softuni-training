using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Toppings = new List<Topping>();
            this.Dough = dough;
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }
        private List<Topping> Toppings { get; set; }

        public int ToppingsCount => this.Toppings.Count;
        public Dough Dough { get; set; }

        public void AddTopping(Topping topping)
        {
            if (this.ToppingsCount == 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }

            this.Toppings.Add(topping);
        }

        public double GetCalories()
        {
            return this.Dough.GetCalories() + this.Toppings.Sum(t => t.GetCalories());
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.GetCalories():f2} Calories.";
        }
    }
}
