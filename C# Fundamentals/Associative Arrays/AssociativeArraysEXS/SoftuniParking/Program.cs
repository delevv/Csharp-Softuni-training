using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftuniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var register = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();
                string command = info[0];
                string name = info[1];

                if (command == "register")
                {
                    string plateNumber = info[2];
                    if (!register.ContainsKey(name))
                    {
                        register[name] = plateNumber;
                        Console.WriteLine($"{name} registered {plateNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {register[name]}");
                    }
                }
                else if (command == "unregister")
                {
                    if (register.ContainsKey(name))
                    {
                        register.Remove(name);
                        Console.WriteLine($"{name} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                }
            }
            foreach (var user in register)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
