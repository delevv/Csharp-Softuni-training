using System;
using System.Collections.Generic;
using System.Linq;

namespace MobaChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var players = new Dictionary<string, Dictionary<string, int>>();

            string command;

            while ((command = Console.ReadLine()) != "Season end")
            {
                List<string> commandArgs = command.Split().ToList();

                if (commandArgs.Contains("->"))
                {
                    commandArgs.RemoveAll(x => x == "->");
                    string player = commandArgs[0];
                    string position = commandArgs[1];
                    int skill = int.Parse(commandArgs[2]);

                    if (!players.ContainsKey(player))
                    {
                        players[player] = new Dictionary<string, int>();
                        players[player][position] = skill;
                    }
                    else
                    {
                        if (players[player].ContainsKey(position))
                        {
                            if (players[player][position] < skill)
                            {
                                players[player][position] = skill;
                            }
                        }
                        else
                        {
                            players[player][position] = skill;
                        }
                    }
                }
                else
                {
                    commandArgs.Remove("vs");
                    string firstPlayer = commandArgs[0];
                    string secondPlayer = commandArgs[1];

                    if (players.ContainsKey(firstPlayer) && players.ContainsKey(secondPlayer))
                    {
                        int firstPlayerTotal = 0;
                        int secondPlayerTotal = 0;
                        string common = "";

                        foreach (var position in players[firstPlayer])
                        {
                            common = position.Key;

                            foreach (var secondPlayerPosition in players[secondPlayer])
                            {
                                if (common == secondPlayerPosition.Key)
                                {
                                    firstPlayerTotal += position.Value;
                                    secondPlayerTotal += secondPlayerPosition.Value;
                                }
                            }
                        }
                        if (firstPlayerTotal > secondPlayerTotal)
                        {
                            players.Remove(secondPlayer);
                        }
                        else if (secondPlayerTotal > firstPlayerTotal)
                        {
                            players.Remove(firstPlayer);
                        }
                    }
                }
            }
            players = players.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var player in players)
            {
                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");

                var currentPlayer = player.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                foreach (var position in currentPlayer)
                {
                    Console.WriteLine($"- {position.Key} <::> {position.Value}");
                }
            }
        }
    }
}
