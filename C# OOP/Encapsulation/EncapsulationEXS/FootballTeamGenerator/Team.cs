using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> Players;

        public Team(string name)
        {
            this.Name = name;
            this.Players = new List<Player>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A name should not be empty.");
                }

                this.name = value;
            }
        }
        public int Rating => CalculateRating();

        public void AddPlayer(Player player)
        {
            this.Players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            var currentPlayer = this.Players.FirstOrDefault(p => p.Name == name);

            if (currentPlayer != null)
            {
                this.Players.Remove(currentPlayer);
            }
            else
            {
                Console.WriteLine($"Player {name} is not in {this.Name} team.");
            }
        }

        public int CalculateRating()
        {
            if (this.Players.Any())
            {
                return (int)Math.Round(this.Players.Sum(p => p.Stats.SkillLevel));
            }
            return 0;
        }
    }
}
