using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace AnimalSanctuary

{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfMessages = int.Parse(Console.ReadLine());

            string infoPattern = @"^n:(?<name>[^;]+);t:(?<kind>[^;]+);c--(?<country>[A-Za-z\s]+)$";
            string cryptedPattern = @"[A-Za-z\s]";
            string weightPattern = @"\d";

            int totalWeight = 0;

            for (int i = 0; i < countOfMessages; i++)
            {
                string message = Console.ReadLine();

                var matchedMessage = Regex.Match(message, infoPattern);

                if (matchedMessage.Success)
                {
                    string cryptedName = matchedMessage.Groups["name"].Value;
                    string cryptedKind = matchedMessage.Groups["kind"].Value;
                    string country = matchedMessage.Groups["country"].Value;

                    var symbolsInName = Regex.Matches(cryptedName, cryptedPattern);
                    var symbolsInKind = Regex.Matches(cryptedKind, cryptedPattern);

                    string name = "";

                    foreach (Match symbol  in symbolsInName)
                    {
                        name += symbol.Value;
                    }
                    string kind = "";

                    foreach (Match symbol in symbolsInKind)
                    {
                        kind += symbol.Value;
                    }
                    Console.WriteLine($"{name} is a {kind} from {country}");

                    var digitsSum = Regex.Matches(message, weightPattern).Cast<Match>().Select(m => m.Value).Select(int.Parse).Sum();

                    totalWeight += digitsSum;
                }
            }
            Console.WriteLine($"Total weight of animals: {totalWeight}KG");
        }
    }
}
