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
                    var matchedInput = Regex.Match(input, pattern);

                    Console.WriteLine(matchedInput.Groups["name"].Value);
                    totalMoney += double.Parse(matchedInput.Groups["price"].Value) * int.Parse(matchedInput.Groups["count"].Value);
                }
            }
            Console.WriteLine($"Total money spend: {totalMoney:f2}");
        }
    }
}
