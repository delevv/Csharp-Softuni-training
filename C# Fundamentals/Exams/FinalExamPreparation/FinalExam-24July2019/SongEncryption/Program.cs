using System;
using System.Text.RegularExpressions;

namespace SongEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPattern = @"^(?<artist>[A-Z][a-z'\s]+):(?<song>[A-Z\s]+)$";

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                var validInput = Regex.Match(command, inputPattern);

                if (validInput.Success)
                {
                    string artist = validInput.Groups["artist"].Value;
                    string song = validInput.Groups["song"].Value;
                    int key = artist.Length;

                    string artistAndSong = artist + ':' + song;
                    string cryptedInfo = "";

                    foreach (var symbol in artistAndSong)
                    {
                        char currentSymbol = symbol;

                        if (currentSymbol + key > 'z')
                        {
                            int remainingLenght = key - ('z' - currentSymbol) - 1;
                            currentSymbol = (char)('a' + remainingLenght);
                        }
                        else if (currentSymbol + key > 'Z' && symbol < 'a')
                        {
                            int remainingLenght = key - ('Z' - currentSymbol) - 1;
                            currentSymbol = (char)('A' + remainingLenght);
                        }
                        else if (currentSymbol == ':')
                        {
                            currentSymbol = '@';
                        }
                        else if (currentSymbol != ' ' && currentSymbol != '\'')
                        {
                            currentSymbol = (char)(currentSymbol + key);
                        }
                        cryptedInfo += currentSymbol;
                    }
                    Console.WriteLine($"Successful encryption: {cryptedInfo}");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
