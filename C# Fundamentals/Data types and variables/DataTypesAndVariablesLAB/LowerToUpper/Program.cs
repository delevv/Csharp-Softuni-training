using System;

namespace LowerToUpper
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            string lowerN = n.ToLower();

            if (n == lowerN) Console.WriteLine("lower-case");
            else Console.WriteLine("upper-case");


        }
    }
}
