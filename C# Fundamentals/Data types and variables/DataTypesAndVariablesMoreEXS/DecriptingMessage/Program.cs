using System;

namespace DecriptingMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int countOfLines = int.Parse(Console.ReadLine());
            string message = "";
            for (int i = 0; i < countOfLines; i++)
            {
                char current = char.Parse(Console.ReadLine());
                message += (char)(current + key);
            }
            Console.WriteLine(message);
        }
    }
}
