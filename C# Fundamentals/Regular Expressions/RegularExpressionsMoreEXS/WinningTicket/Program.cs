using System;
using System.Text.RegularExpressions;

namespace WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tickets = Regex.Split(Console.ReadLine(), @"\s*,\s+");

            string validTicketPattern = @"^.{20}$";
            string matchTicketPattern = @"\${6,10}|@{6,10}|\#{6,10}|\^{6,10}";

            for (int i = 0; i < tickets.Length; i++)
            {
                string currentTicket = tickets[i];

                if (Regex.IsMatch(currentTicket, validTicketPattern))
                {
                    string leftSide = currentTicket.Substring(0, 10);
                    string rightSide = currentTicket.Substring(10, 10);

                    var leftSideMatch = Regex.Match(leftSide, matchTicketPattern);
                    var rightSideMatch = Regex.Match(rightSide, matchTicketPattern);

                    bool isBothSidesEqual = false;

                    if (leftSideMatch.Success && rightSideMatch.Success && leftSideMatch.ToString() == rightSideMatch.ToString())
                    {
                        isBothSidesEqual = true;
                    }
                    else if(leftSideMatch.Success && rightSideMatch.Success && leftSideMatch.ToString() != rightSideMatch.ToString())
                    {
                        if (leftSideMatch.ToString().Contains(rightSideMatch.ToString()))
                        {
                            isBothSidesEqual = true;
                        }
                        else if (rightSideMatch.ToString().Contains(leftSideMatch.ToString()))
                        {
                            isBothSidesEqual = true;
                        }
                    }
                    if (isBothSidesEqual)
                    {
                        char symbol = leftSideMatch.ToString()[0];
                        int count = Math.Min(leftSideMatch.ToString().Length,rightSideMatch.ToString().Length);

                        if (count == 10)
                        {
                            Console.WriteLine($"ticket \"{currentTicket}\" - {count}{symbol} Jackpot!");
                        }
                        else
                        {
                            Console.WriteLine($"ticket \"{currentTicket}\" - {count}{symbol}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{currentTicket}\" - no match");
                    }
                }
                else
                {
                    Console.WriteLine("invalid ticket");
                }
            }
        }
    }
}
