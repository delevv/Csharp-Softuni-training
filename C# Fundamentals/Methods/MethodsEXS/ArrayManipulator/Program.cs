using System;
using System.Linq;

namespace ArrayManipulator
{
    class Program
    {
        static int[] Exchange(int[] numbers,int exchangeIndex)
        {
            int[] exchange = new int[numbers.Length];
            int indexCount = 0;
            for (int i = exchangeIndex + 1; i < exchange.Length; i++)
            {
                exchange[indexCount] = numbers[i];
                indexCount++;
            }
            for (int i = 0; i <= exchangeIndex; i++)
            {
                exchange[indexCount] = numbers[i];
                indexCount++;
            }
            return exchange;
        }
        static void PrintMaxEvenOrOddIndex(int[]numbers,string type)
        {
            int maxEven = int.MinValue;
            int maxEvenIndex = -1;
            int maxOdd = int.MinValue;
            int maxOddIndex = -1;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    if (numbers[i] >= maxEven)
                    {
                        maxEven = numbers[i];
                        maxEvenIndex = i;
                    }
                }
                else
                {
                    if (numbers[i] >= maxOdd)
                    {
                        maxOdd = numbers[i];
                        maxOddIndex = i;
                    }
                }
            }
            if (type == "even"&& maxEvenIndex!=-1)
            {
                Console.WriteLine(maxEvenIndex);
            }
            else if (type == "odd" && maxOddIndex!=-1)
            {
                Console.WriteLine(maxOddIndex);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
        static void PrintMinEvenOrOddIndex(int[]numbers,string type)
        {
            int minEven = int.MaxValue;
            int minEvenIndex = -1;
            int minOdd = int.MaxValue;
            int minOddIndex = -1;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    if (numbers[i] <= minEven)
                    {
                        minEven = numbers[i];
                        minEvenIndex = i;
                    }
                }
                else
                {
                    if (numbers[i] <= minOdd)
                    {
                        minOdd = numbers[i];
                        minOddIndex = i;
                    }
                }
            }
            if (type == "even" && minEvenIndex!=-1 )
            {
                Console.WriteLine(minEvenIndex);
            }
            else if (type == "odd" && minOddIndex!=-1)
            {
                Console.WriteLine(minOddIndex);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
        static void PrintFirstOrLastEvenOrOddElements(int[]numbers,string firstOrLast,int count,string type)
        {
            if (count > numbers.Length)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                int currentEvenCount = 0;
                int currentOddCount = 0;
                int[] evenElements = new int[numbers.Length];
                int[] oddElements = new int[numbers.Length];
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 == 0)
                    {
                        evenElements[currentEvenCount] = numbers[i];
                        currentEvenCount++;
                    }
                    else
                    {
                        oddElements[currentOddCount] = numbers[i];
                        currentOddCount++;
                    }
                }
                if (type=="odd" && count>currentOddCount)
                {
                    count = currentOddCount;
                }
                else if (type=="even" && count > currentEvenCount)
                {
                    count = currentEvenCount;
                }
                if (firstOrLast == "first")
                {
                    if (type == "odd")
                    {
                        Console.Write("[");
                        for (int i = 0; i < count; i++)
                        {
                            Console.Write(oddElements[i]);
                            if (i != count - 1) Console.Write(", ");
                        }
                        Console.WriteLine("]");
                    }
                    else if (type == "even")
                    {
                        Console.Write("[");
                        for (int i = 0; i < count; i++)
                        {
                            Console.Write(evenElements[i]);
                            if (i != count - 1) Console.Write(", ");
                        }
                        Console.WriteLine("]");
                    }
                }
                else if (firstOrLast == "last")
                {
                    if (type == "odd")
                    {
                        Console.Write("[");
                        for (int i = currentOddCount - count; i < currentOddCount ; i++)
                        {
                            Console.Write(oddElements[i]);
                            if (i < currentOddCount-1) Console.Write(", ");
                        }
                        Console.WriteLine("]");
                    }
                    else if (type == "even")
                    {
                        Console.Write("[");
                        for (int i = currentEvenCount - count; i < currentEvenCount ; i++)
                        {
                            Console.Write(evenElements[i]);
                            if (i < currentEvenCount-1) Console.Write(", ");
                        }
                        Console.WriteLine("]");
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] commandSplit = command.Split().ToArray();
                if (commandSplit[0] == "exchange")
                {
                    int exchangeIndex = int.Parse(commandSplit[1]);

                    if(exchangeIndex>=0 && exchangeIndex<= numbers.Length - 1)
                    {
                        numbers = Exchange(numbers, exchangeIndex);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (commandSplit[0] == "max")
                {
                    PrintMaxEvenOrOddIndex(numbers, commandSplit[1]);
                }
                else if (commandSplit[0] == "min")
                {
                    PrintMinEvenOrOddIndex(numbers, commandSplit[1]);
                }
                else if (commandSplit[0] == "first" || commandSplit[0]=="last")
                {
                    int count = int.Parse(commandSplit[1]);
                    PrintFirstOrLastEvenOrOddElements(numbers,commandSplit[0], count, commandSplit[2]);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }
    }
}
