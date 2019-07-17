using System;

namespace VowelsCount
{
    class Program
    {
        static int VowelsCount(string text)
        {
            int count = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char currentDigit = text[i];
                switch (currentDigit)
                {
                    case 'a':
                    case 'e':
                    case 'o':
                    case 'u':
                    case 'i':
                    case 'A':
                    case 'E':
                    case 'O':
                    case 'U':
                    case 'I':
                        count++;
                        break;
                }
            }
            return count;
        }
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Console.WriteLine(VowelsCount(text));
        }
    }
}
