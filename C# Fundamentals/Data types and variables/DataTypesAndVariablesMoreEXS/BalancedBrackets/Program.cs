using System;

namespace BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int bracketDiff = 0;
            for (int i = 0; i < count; i++)
            {
                string text = Console.ReadLine();
                if(text==")" && bracketDiff == 0)
                {
                    Console.WriteLine("UNBALANCED");
                    return;
                }
                if (text == "(") bracketDiff++;
                else if (text == ")") bracketDiff--;
            }
            if (bracketDiff == 0) Console.WriteLine("BALANCED");
            else Console.WriteLine("UNBALANCED");
        }
    }
}
