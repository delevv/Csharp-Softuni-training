using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
        private const int MagicCardInitialDamagePoints = 5;
        private const int MagicCardInitialHealthPoints = 80;

        public MagicCard(string name) 
            : base(name, MagicCardInitialDamagePoints, MagicCardInitialHealthPoints)
        {
        }
    }
}
