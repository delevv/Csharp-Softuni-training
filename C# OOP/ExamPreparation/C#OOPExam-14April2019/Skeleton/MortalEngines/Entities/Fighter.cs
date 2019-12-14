using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        private const int FighterInitalHealthPoints= 200;
        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, FighterInitalHealthPoints)
        {
            this.AggressiveMode = false;
            this.ToggleAggressiveMode();
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == true)
            {
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
                this.AggressiveMode = false;
            }
            else
            {
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
                this.AggressiveMode = true;
            }
        }

        public override string ToString()
        {
            var aggressiveOrNot = this.AggressiveMode == true ? "ON" : "OFF";
            
            return base.ToString() + Environment.NewLine + $" *Aggressive: {aggressiveOrNot}";
        }
    }
}
