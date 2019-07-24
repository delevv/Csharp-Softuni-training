using System;
using System.Text.RegularExpressions;

namespace TheIsleofManTTRace
{
    class Program
    {
        static void Main(string[] args)
        {
            string messagePattern = @"^([#$%*&])(?<name>[A-Za-z]+)\1=(?<lenght>\d+)!!(?<code>.+)$";

            while (true)
            {
                string message = Console.ReadLine();

                var matchedMessage = Regex.Match(message, messagePattern);

                if (matchedMessage.Success)
                {
                    string name = matchedMessage.Groups["name"].Value;
                    string code = matchedMessage.Groups["code"].Value;
                    int lenght = int.Parse(matchedMessage.Groups["lenght"].Value);

                    if (code.Length == lenght)
                    {
                        string decriptedCode = "";

                        for (int i = 0; i < code.Length; i++)
                        {
                            decriptedCode += (char)(code[i] + lenght);
                        }
                        Console.WriteLine($"Coordinates found! {name} -> {decriptedCode}");
                        break;
                    }
                }
                Console.WriteLine("Nothing found!");
            }
        }
    }
}