using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const int InitialAmountOfOxygen = 70;
        private const int AmountOxygenForBreath = 5;

        public Biologist(string name)
            : base(name, InitialAmountOfOxygen)
        {
        }

        public override void Breath()
        {
            this.Oxygen = Math.Max(this.Oxygen - AmountOxygenForBreath, 0);
        }
    }
}
