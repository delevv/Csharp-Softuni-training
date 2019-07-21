using System;
using System.Text.RegularExpressions;

namespace Santa_sSecretHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
    
            string validNamePattern = @"@([a-zA-Z]+)[^@\-!:>]*!([GN])!";

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string message = "";

                for (int i = 0; i < command.Length; i++)
                {
                    message += (char)(command[i] - key);
                }

                var matchedName = Regex.Match(message, validNamePattern);

                if (matchedName.Success)
                {
                    if (matchedName.Groups[2].ToString() == "G")
                    {
                        Console.WriteLine(matchedName.Groups[1]);
                    }
                }
            }
        }
    }
}
