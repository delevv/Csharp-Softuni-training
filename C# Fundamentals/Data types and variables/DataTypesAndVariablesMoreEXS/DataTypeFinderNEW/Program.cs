using System;

namespace DataTypeFinderNEW
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            while (word != "END")
            {
                bool isInt = int.TryParse(word, out int integer);
                bool isFloat = float.TryParse(word, out float floating);
                bool isChar = char.TryParse(word, out char character);
                bool isBool = bool.TryParse(word, out bool boolean);

                if (isInt) Console.WriteLine($"{word} is integer type");
                else if (isFloat) Console.WriteLine($"{word} is floating point type");
                else if (isChar) Console.WriteLine($"{word} is character type");
                else if (isBool) Console.WriteLine($"{word} is boolean type");
                else Console.WriteLine($"{word} is string type");

                word = Console.ReadLine();
            }
        }
    }
}
