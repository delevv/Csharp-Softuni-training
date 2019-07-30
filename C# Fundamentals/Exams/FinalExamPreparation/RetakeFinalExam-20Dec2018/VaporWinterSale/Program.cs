using System;
using System.Collections.Generic;
using System.Linq;

namespace VaporWinterSale
{
    class DlcAndPrice
    {
        public string DlcName { get; set; }
        public double Price { get; set; }

        public DlcAndPrice(string name,double price)
        {
            this.DlcName = name;
            this.Price = price;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");

            var gamesWithDlc = new Dictionary<string, DlcAndPrice>();
            var games = new Dictionary<string, double>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Contains(":"))
                {
                    string[] info = input[i].Split(":");

                    string game = info[0];
                    string dlc = info[1];

                    if (games.ContainsKey(game))
                    {
                        DlcAndPrice current = new DlcAndPrice(dlc, games[game] * 1.20);
                        gamesWithDlc[game] = current;
                        games.Remove(game);
                    }
                }
                else
                {
                    string[] info = input[i].Split("-");

                    string game = info[0];
                    double price = double.Parse(info[1]);

                    if (!games.ContainsKey(game))
                    {
                        games[game] = price;
                    }
                }
            }
            foreach (var game in gamesWithDlc.OrderBy(x=>x.Value.Price))
            {
                    Console.WriteLine($"{game.Key} - {game.Value.DlcName} - {game.Value.Price * 0.5:f2}");
            }
            foreach (var game in games.OrderByDescending(x=>x.Value))
            {
                Console.WriteLine($"{game.Key} - {game.Value*0.80:f2}");
            }
        }
    }
}
