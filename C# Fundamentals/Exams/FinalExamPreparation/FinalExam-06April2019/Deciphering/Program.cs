using System;
using System.Text.RegularExpressions;
using System.Text;

namespace Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            string validTextPattern = @"^[d-z{},|#]+$";

            string text = Console.ReadLine();
            string[] substrings = Console.ReadLine().Split(" ");

            var validText = Regex.Match(text, validTextPattern);

            if (validText.Success)
            {
                var decryptedText = new StringBuilder();

                for (int i = 0; i < validText.Value.Length; i++)
                {
                    decryptedText.Append((char)(validText.Value[i] - 3));
                }
                decryptedText = decryptedText.Replace(substrings[0], substrings[1]);

                Console.WriteLine(decryptedText);
            }
            else
            {
                Console.WriteLine("This is not the book you are looking for.");
            }
        }
    }
}
