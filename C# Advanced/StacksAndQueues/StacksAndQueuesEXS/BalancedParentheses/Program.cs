using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequenceOfParantheses = Console.ReadLine();

            var openBrackets = new Stack<char>();

            if (sequenceOfParantheses.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }
            var isBalanced = true;

            for (int i = 0; i < sequenceOfParantheses.Length; i++)
            {
                if (sequenceOfParantheses[i] == '(' || sequenceOfParantheses[i] == '[' || sequenceOfParantheses[i] == '{')
                {
                    openBrackets.Push(sequenceOfParantheses[i]);
                }
                else
                {
                    var open = openBrackets.Pop();
                    var closed = sequenceOfParantheses[i];

                    if (open == '(' && closed == ')')
                    {
                        isBalanced = true;
                    }
                    else if (open == '{' && closed == '}')
                    {
                        isBalanced = true;
                    }
                    else if (open == '[' && closed == ']')
                    {
                        isBalanced = true;
                    }
                    else
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }
            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
