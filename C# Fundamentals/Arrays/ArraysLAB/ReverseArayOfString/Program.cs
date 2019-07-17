using System;
using System.Linq;

namespace ReverseArayOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrayOfStrings = Console.ReadLine().Split().ToArray();

            for (int i = arrayOfStrings.Length-1; i >= 0; i--)
            {
                Console.Write(arrayOfStrings[i] + " ");
            }
        }
    }
}
