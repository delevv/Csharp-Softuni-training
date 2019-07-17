using System;

namespace MethodsMoreEXS
{
    class Program
    {

        static void DataType(string input)
        {
            Console.WriteLine("$"+input+"$");
        }
        static void DataType(int input)
        {
            Console.WriteLine(input*2);
        }
        static void DataType(double input)
        {
            Console.WriteLine($"{input*1.5:f2}");
        }
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            if (type == "int")
            {
                int input = int.Parse(Console.ReadLine());
                DataType(input);
            }
            else if (type == "real")
            {
               double input = double.Parse(Console.ReadLine());
                DataType(input);
            }
            else
            {
                string input = Console.ReadLine();
                DataType(input);
            }
        }
    }
}
