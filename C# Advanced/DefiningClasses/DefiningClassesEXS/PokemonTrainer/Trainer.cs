using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public string Name { get; set; }
        public int NumberOfBadges { get; set; } = 0;
        public List<Pokemon> PokemonCollection { get; set; }

        public Trainer(string name, List<Pokemon> pokemonCollection)
        {
            Name = name;
            PokemonCollection = pokemonCollection;
        }

        public void RemoveDeadPokemons()
        {
            this.PokemonCollection.RemoveAll(p => p.Health <= 0);
        }
    }
}
