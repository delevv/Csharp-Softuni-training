using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var trainers = new Dictionary<string, Trainer>();
            var command = "";

            while ((command = Console.ReadLine()) != "Tournament")
            {
                var commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var trainerName = commandArgs[0];
                var pokemonName = commandArgs[1];
                var pokemonElement = commandArgs[2];
                var pokemonHealth = int.Parse(commandArgs[3]);

                var currentPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers[trainerName] = new Trainer(trainerName, new List<Pokemon>());
                }
                trainers[trainerName].PokemonCollection.Add(currentPokemon);
            }

            while ((command = Console.ReadLine()) != "End")
            {
                var element = command;

                foreach (var  trainer in trainers)
                {
                    var isHavingEelement = trainer.Value.PokemonCollection.Any(p => p.Element == element);

                    if (isHavingEelement)
                    {
                        trainer.Value.NumberOfBadges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Value.PokemonCollection)
                        {
                            pokemon.Health -= 10;
                        }
                        trainer.Value.RemoveDeadPokemons();
                    }
                }
            }
            foreach (var trainer in trainers.OrderByDescending(t=>t.Value.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.NumberOfBadges} {trainer.Value.PokemonCollection.Count}");
            }
        }
    }
}
