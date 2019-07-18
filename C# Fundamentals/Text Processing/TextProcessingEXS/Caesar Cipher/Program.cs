using System;

namespace Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string result="";
            for (int i = 0; i < text.Length; i++)
            {
                result += (char)(text[i] + 3);
            }
            Console.WriteLine(result);
        }
    }
}
