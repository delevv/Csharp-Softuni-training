using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var expression = Console.ReadLine();

            var openIndexes = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    openIndexes.Push(i);
                }
                else if (expression[i] == ')')
                {
                    var startIndex = openIndexes.Pop();
                    var endIndex = i;

                    Console.WriteLine(expression.Substring(startIndex,endIndex-startIndex+1));
                }
            }
        }
    }
}
