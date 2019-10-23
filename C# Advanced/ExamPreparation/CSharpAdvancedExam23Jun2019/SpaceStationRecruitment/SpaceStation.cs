using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private List<Astronaut> data;

        public SpaceStation(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Astronaut>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count;

        public void Add(Astronaut astronaut)
        {
            if (data.Count < this.Capacity)
            {
                this.data.Add(astronaut);
            }
        }
         
        public bool Remove(string name)
        {
            if (this.data.Any(a => a.Name == name))
            {
                var currentAstronaut = this.data.Where(a => a.Name == name).FirstOrDefault();
                this.data.Remove(currentAstronaut);

                return true;
            }
            else
            {
                return false;
            }
        }

        public Astronaut GetOldestAstronaut()
        {
            return this.data.OrderByDescending(a => a.Age).FirstOrDefault();
        }

        public Astronaut GetAstronaut(string name)
        {
            return this.data.Where(a => a.Name == name).FirstOrDefault();
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var astronaut in this.data)
            {
                sb.AppendLine($"{astronaut}");
            }

            return sb.ToString().Trim();
        }
    }
}
