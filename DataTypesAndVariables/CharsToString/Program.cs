using System;

namespace CharsToString
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "";
            for (int i = 0; i < 3; i++)
            {
                name+= char.Parse(Console.ReadLine());
            }
            Console.WriteLine(name);
        }
    }
}
