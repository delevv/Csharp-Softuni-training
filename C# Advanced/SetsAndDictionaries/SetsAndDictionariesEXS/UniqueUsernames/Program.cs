using System;
using System.Collections.Generic;

namespace UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var countOfUsernames = int.Parse(Console.ReadLine());

            var users = new HashSet<string>();

            for (int i = 0; i < countOfUsernames; i++)
            {
                users.Add(Console.ReadLine());
            }
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }
    }
}
