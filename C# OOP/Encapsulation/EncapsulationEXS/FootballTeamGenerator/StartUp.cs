using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var teams = new List<Team>();

            var command = "";

            while ((command = Console.ReadLine()) != "END")
            {
                var commandArgs = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
                var action = commandArgs[0];

                try
                {
                    if (action == "Team")
                    {
                        var name = commandArgs[1];

                        var team = new Team(name);

                        teams.Add(team);
                    }
                    else if (action == "Add")
                    {
                        var teamName = commandArgs[1];

                        var currentTeam = teams.FirstOrDefault(t => t.Name == teamName);

                        if (currentTeam != null)
                        {
                            var playerName = commandArgs[2];

                            var endurance = int.Parse(commandArgs[3]);
                            var sprint = int.Parse(commandArgs[4]);
                            var dribble = int.Parse(commandArgs[5]);
                            var passing = int.Parse(commandArgs[6]);
                            var shooting = int.Parse(commandArgs[7]);

                            var stats = new Stats(endurance, sprint, dribble, passing, shooting);

                            var player = new Player(playerName, stats);

                            currentTeam.AddPlayer(player);
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                    }
                    else if (action == "Remove")
                    {
                        var teamName = commandArgs[1];
                        var playerName = commandArgs[2];

                        var currentTeam = teams.FirstOrDefault(t => t.Name == teamName);

                        currentTeam.RemovePlayer(playerName);
                    }
                    else if (action == "Rating")
                    {
                        var teamName = commandArgs[1];

                        var currentTeam = teams.FirstOrDefault(t => t.Name == teamName);

                        if (currentTeam != null)
                        {
                            Console.WriteLine($"{currentTeam.Name} - {currentTeam.Rating}");
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}

