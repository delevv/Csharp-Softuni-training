using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        private const int TrapCardInitialDamagePoints = 120;
        private const int TrapCardInitialHealthPoints = 5;

        public TrapCard(string name) 
            : base(name, TrapCardInitialDamagePoints, TrapCardInitialHealthPoints)
        {
        }
    }
}
