using System;

namespace GreaterOfTwoValues
{
    class Program
    {
        static string GetMax(string type,string firstValue,string secondValue)
        {
            string maxValue = "";
            if (type == "int")
            {
                int first = int.Parse(firstValue);
                int second = int.Parse(secondValue);
                if (first > second) maxValue = firstValue;
                else maxValue = secondValue;
            }
            else if (type == "char")
            {
                char first = char.Parse(firstValue);
                char second = char.Parse(secondValue);
                if (first > second) maxValue = firstValue;
                else maxValue = secondValue;
            }
            else if (type == "string")
            {
                if (firstValue.CompareTo(secondValue) >= 0) maxValue = firstValue;
                else maxValue = secondValue;
            }
            return maxValue;
        }
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string firstValue = Console.ReadLine();
            string secondValue = Console.ReadLine();
            Console.WriteLine(GetMax(type,firstValue,secondValue));
        }
    }
}
