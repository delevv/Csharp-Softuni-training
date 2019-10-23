using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Salad
    {
        public string Name { get; set; }

        private List<Vegetable> vegetables;

        public Salad(string name)
        {
            this.Name = name;
            this.vegetables = new List<Vegetable>();
        }

        public int GetTotalCalories()
        {
            return vegetables.Sum(v => v.Calories);
        }

        public int GetProductCount()
        {
            return vegetables.Count();
        }

        public void Add(Vegetable product)
        {
            vegetables.Add(product);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"* Salad {this.Name} is {GetTotalCalories()} calories and have {GetProductCount()} products:");

            foreach (var vegetable in vegetables)
            {
                sb.AppendLine(vegetable.ToString());
            }

            return  sb.ToString().Trim();
        }
    }
}
