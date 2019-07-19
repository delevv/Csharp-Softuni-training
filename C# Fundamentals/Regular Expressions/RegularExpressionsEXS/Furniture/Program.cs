using System;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bought furniture: ");
            double totalMoney = 0;
            string command;

            while ((command = Console.ReadLine()) != "Purchase")
            {
                string pattern = @">>(?<name>.+)<<(?<price>\d+\.?\d+)!(?<count>\d+)";
                string input = command;

                if (Regex.IsMatch(input, pattern))
                {
                    var matchedInput = Regex.Matches(input, pattern);

                    foreach (Match match in matchedInput)
                    {
                        Console.WriteLine(match.Groups["name"].Value);
                        totalMoney += double.Parse(match.Groups["price"].Value)*int.Parse(match.Groups["count"].Value);
                    }
                }
            }
            Console.WriteLine($"Total money spend: {totalMoney:f2}");
        }
    }
}
