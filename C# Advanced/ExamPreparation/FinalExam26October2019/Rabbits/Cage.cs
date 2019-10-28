using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> data;

        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Rabbit>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count;

        public void Add(Rabbit rabbit)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {
            var isRemoved = false;
            if (this.data.Any(r => r.Name == name))
            {
                var currentRabbit = this.data.Where(r => r.Name == name).FirstOrDefault();
                this.data.Remove(currentRabbit);
                isRemoved = true;
            }
            return isRemoved;
        }

        public void RemoveSpecies(string species)
        {
            this.data = this.data.Where(r => r.Species != species).ToList();
        }

        public Rabbit SellRabbit(string name)
        {
            Rabbit currentRabbit = null;

            for (int i = 0; i < this.data.Count; i++)
            {
                if (this.data[i].Name == name)
                {
                    this.data[i].Available = false;
                    currentRabbit = this.data[i];
                }
            }

            return currentRabbit;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            var listOfRabbits = new List<Rabbit>();

            for (int i = 0; i < this.data.Count; i++)
            {
                if (this.data[i].Species == species)
                {
                    listOfRabbits.Add(SellRabbit(this.data[i].Name));
                }
            }

            return listOfRabbits.ToArray();
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Rabbits available at {this.Name}:");

            foreach (var rabbit in this.data.Where(r=>r.Available==true))
            {
                sb.AppendLine(rabbit.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
