using System;

namespace MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int secondNumber = int.Parse(Console.ReadLine());
            string result = "";
            int remainder = 0;

            number = number.TrimStart('0');

            for (int i = number.Length - 1; i >= 0; i--)
            {
                string currentResult = ((number[i] - '0') * secondNumber + remainder).ToString();

                if (currentResult.Length > 1)
                {
                    result += currentResult[1];
                    remainder = (currentResult[0] - '0');
                }
                else
                {
                    result += currentResult[0];
                    remainder = 0;
                }
                if (i == 0 && remainder > 0) result += remainder;
            }

            string reversedResult = "";

            for (int i = result.Length - 1; i >= 0; i--)
            {
                reversedResult += result[i];
            }
            if (reversedResult[0] - '0' == 0)
            {
                reversedResult = "0";
            }
            Console.WriteLine(reversedResult);
        }
    }
}
