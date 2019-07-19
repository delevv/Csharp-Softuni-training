using System;
using System.Text.RegularExpressions;

namespace SoftuniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<name>[A-Z][a-z]+)%[^\$\|\%\.]*<(?<product>\w+)>[^\$\|\%\.]*\|(?<count>\d+)\|[^\$\|\%\.\d]*(?<price>\d+(\.\d+)?)\$";
            double totalIncome = 0;
            string command;

            while ((command = Console.ReadLine()) != "end of shift")
            {
                if (Regex.IsMatch(command, pattern))
                {
                    var matchedOrder = Regex.Match(command, pattern);

                    string name = matchedOrder.Groups["name"].Value;
                    string product = matchedOrder.Groups["product"].Value;
                    int count = int.Parse(matchedOrder.Groups["count"].Value);
                    double price = double.Parse(matchedOrder.Groups["price"].Value);

                    Console.WriteLine($"{name}: {product} - {count * price:f2}");
                    totalIncome += count * price;
                }
            }
            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
