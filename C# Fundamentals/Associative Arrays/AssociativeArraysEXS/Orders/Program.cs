using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            var productDict = new Dictionary<string, List<double>>();

            string command;

            while ((command = Console.ReadLine()) != "buy")
            {
                string[] productInfo = command.Split();

                string name = productInfo[0];
                double price = double.Parse(productInfo[1]);
                double quantity= double.Parse(productInfo[2]);

                if (!productDict.ContainsKey(name))
                {
                    productDict[name] = new List<double>() { price, quantity };
                }
                else
                { 
                    productDict[name][0] = price;
                    productDict[name][1] += quantity;
                }
            }
            foreach (var product in productDict)
            {
                Console.WriteLine($"{product.Key} -> {product.Value[0]*product.Value[1]:f2}");
            }
        }
    }
}
