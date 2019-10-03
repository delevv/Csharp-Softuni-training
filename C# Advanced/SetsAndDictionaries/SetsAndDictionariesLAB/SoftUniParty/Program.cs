using System;
using System.Collections.Generic;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var vipPartyList = new HashSet<string>();
            var normalPartyList = new HashSet<string>();
            var command = "";

            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "PARTY")
                {
                    while((command = Console.ReadLine()) != "END")
                    {
                        if (char.IsDigit(command[0]))
                        {
                            vipPartyList.Remove(command);
                        }
                        else
                        {
                            normalPartyList.Remove(command)
                        }
                    }
                    break;
                }
                else
                {
                    if (char.IsDigit(command[0]))
                    {
                        vipPartyList.Add(command);
                    }
                    else
                    {
                        normalPartyList.Add(command)
                    }
                }
            }
            Console.WriteLine(vipPartyList.Count);

            foreach (var name in vipPartyList)
            {
                Console.WriteLine(name);
            }
            foreach (var name in normalPartyList)
            {
                Console.WriteLine(name);
            }
        }
    }
}
