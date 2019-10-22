using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightingArena
{
    public class Arena
    {
        private List<Gladiator> gladiators;
        public string Name { get; set; }
        public int Count => this.gladiators.Count;

        public Arena(string name)
        {
            this.gladiators = new List<Gladiator>();
            this.Name = name;
        }

        public void Add(Gladiator gladiator)
        {
            this.gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            var gladiatorToRemove = gladiators.Where(g => g.Name == name).FirstOrDefault();

            this.gladiators.Remove(gladiatorToRemove);
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            return this.gladiators.OrderByDescending(g => g.GetStatPower()).FirstOrDefault();
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            return this.gladiators.OrderByDescending(g => g.GetWeaponPower()).FirstOrDefault();
        }

        public  Gladiator GetGladitorWithHighestTotalPower()
        {
            return this.gladiators.OrderByDescending(g => g.GetTotalPower()).FirstOrDefault();
        }

        public override string ToString()
        {
            return $"[{this.Name}] - [{this.Count}] gladiators are participating.";
        }
    }
}
