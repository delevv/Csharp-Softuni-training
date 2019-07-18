using System;

namespace StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] splittedInput = Console.ReadLine().Split(">");
            string result = splittedInput[0];
            int power = 0;
            for (int i = 1; i < splittedInput.Length; i++)
            {
                result += ">";
                power += splittedInput[i][0] - '0';

                if (power > splittedInput[i].Length)
                {
                    power -= splittedInput[i].Length;
                }
                else
                {
                    result += splittedInput[i].Substring(power);
                    power = 0;
                }
            }
            Console.WriteLine(result);
        }
    }
}
