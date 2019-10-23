using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Restaurant
    {
        private List<Salad> data;

        public Restaurant(string name)
        {
            Name = name;
            this.data = new List<Salad>();
        }

        public string Name { get; set; }

        public void Add(Salad salad)
        {
            data.Add(salad);
        }

        public bool Buy(string name)
        {
            if (data.Any(s => s.Name == name))
            {
                var salad = data.Where(s => s.Name == name).FirstOrDefault();
                data.Remove(salad);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Salad GetHealthiestSalad()
        {
            return data.OrderBy(s => s.GetTotalCalories()).FirstOrDefault();
        }

        public string GenerateMenu()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Name} have {this.data.Count()} salads:");

            foreach (var salad in data)
            {
                sb.AppendLine(salad.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
