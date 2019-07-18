using System;

namespace ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(", ");

            for (int i = 0; i < names.Length; i++)
            {
                if(names[i].Length>=3 && names[i].Length <= 16)
                {
                    bool isValid = true;
                    foreach (var symbol in names[i])
                    {
                        if (!char.IsLetterOrDigit(symbol))
                        {
                            if(symbol!='-' && symbol != '_')
                            {
                                isValid = false;
                                break;
                            }
                        }
                    }
                    if (isValid)
                    {
                        Console.WriteLine(names[i]);
                    }
                }
            }
        }
    }
}
