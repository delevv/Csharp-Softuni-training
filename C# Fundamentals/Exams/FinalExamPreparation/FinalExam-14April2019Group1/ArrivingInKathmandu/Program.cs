using System;
using System.Text.RegularExpressions;

namespace ArrivingInKathmandu
{
    class Program
    {
        static void Main(string[] args)
        {
            string messagePattern = @"^(?<name>[A-Za-z0-9!@#$?]+)=(?<lenght>[0-9]+)<<(?<code>.+)$";
            string namePattern = @"[A-Za-z0-9]";

            string command;

            while((command=Console.ReadLine())!="Last note")
            {
                var validMessage = Regex.Match(command, messagePattern);

                if (validMessage.Success)
                {
                    string name = validMessage.Groups["name"].Value;
                    int lenght = int.Parse(validMessage.Groups["lenght"].Value);
                    string code = validMessage.Groups["code"].Value;

                    if (lenght == code.Length)
                    {
                        var nameSymbols = Regex.Matches(name, namePattern);
                        name = "";
                        foreach (var symbol in nameSymbols)
                        {
                            name += symbol;
                        }
                        Console.WriteLine($"Coordinates found! {name} -> {code}");
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }
            }
        }
    }
}
