using System;

namespace Orders
{
    class Program
    {
        static void OrderPrice(string product,int count)
        {
            double price = 0;
            switch (product)
            {
                case "coffee": price = 1.5;
                    break;
                case "water":
                    price = 1.00;
                    break;
                case "coke":
                    price = 1.40;
                    break;
                case "snacks":
                    price = 2.00;
                    break;
            }
            Console.WriteLine($"{price*count:f2}");
        }
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());
            OrderPrice(product, count);
        }
    }
}
