using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FightingArena
{
    public class Gladiator
    {
        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            this.Name = name;
            this.Stat = stat;
            this.Weapon = weapon;
        }

        public string Name { get; set; }
        public Stat Stat { get; set; }
        public Weapon Weapon { get; set; }

        public int GetTotalPower()
        {
            return GetStatPower() + GetWeaponPower();
        }

        public int GetWeaponPower()
        {
            return this.Weapon.Sharpness +
                this.Weapon.Size +
                this.Weapon.Solidity;
        }

        public int GetStatPower()
        {
            return this.Stat.Agility +
                this.Stat.Flexibility +
                this.Stat.Intelligence +
                this.Stat.Skills +
                this.Stat.Strength;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"[{this.Name}] - [{GetTotalPower()}]");
            sb.AppendLine($"  Weapon Power: [{GetWeaponPower()}]");
            sb.AppendLine($"  Stat Power: [{GetStatPower()}]");

            return sb.ToString().Trim(); 
        }
    }
}
