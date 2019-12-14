using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        private const int TankInitialHealthPoints = 100;
        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, TankInitialHealthPoints)
        {
            this.DefenseMode = false;
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == true)
            {
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
                this.DefenseMode = false;
            }
            else
            {
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
                this.DefenseMode = true;
            }
        }

        public override string ToString()
        {
            var defenseOrNot = this.DefenseMode == true ? "ON" : "OFF";

            return base.ToString() + Environment.NewLine + $" *Defense: {defenseOrNot}";
        }
    }
}
