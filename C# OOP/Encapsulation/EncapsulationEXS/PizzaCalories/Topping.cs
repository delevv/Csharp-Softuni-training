using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Topping
    {
        private Dictionary<string, double> modifiers;
        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.modifiers = new Dictionary<string, double>
            {
                ["meat"] = 1.2,
                ["veggies"] = 0.8,
                ["cheese"] = 1.1,
                ["sauce"] = 0.9
            };

            this.Type = type;
            this.Weight = weight;
        }

        private double Weight
        {
            get => weight;
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new Exception($"{this.Type} weight should be in the range [1..50].");
                }
                this.weight = value;
            }

        }
        private string Type
        {
            get => type;
            set
            {
                if (!this.modifiers.ContainsKey(value.ToLower()))
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }
                else
                {
                    this.type = value;
                }
            }
        }

        public double GetCalories()
        {
            return this.Weight * (2 * this.modifiers[this.Type.ToLower()]);
        }
    }
}
