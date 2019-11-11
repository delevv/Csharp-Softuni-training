using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var peoplesInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            var productsInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            var people = new List<Person>();
            var products = new List<Product>();

            try
            {
                for (int i = 0; i < peoplesInfo.Length; i++)
                {
                    var currentPersonInfo = peoplesInfo[i].Split("=");

                    var name = currentPersonInfo[0];
                    var money = decimal.Parse(currentPersonInfo[1]);

                    var person = new Person(name, money);

                    people.Add(person);
                }

                for (int i = 0; i < productsInfo.Length; i++)
                {
                    var currentProductInfo = productsInfo[i].Split("=");

                    var name = currentProductInfo[0];
                    var cost = decimal.Parse(currentProductInfo[1]);

                    var product = new Product(name, cost);

                    products.Add(product);
                }

                var command = "";

                while ((command = Console.ReadLine()) != "END")
                {
                    var purchase = command.Split();

                    var personName = purchase[0];
                    var productName = purchase[1];

                    var currentPerson = people.FirstOrDefault(per => per.Name == personName);

                    var currentProduct = products.FirstOrDefault(p => p.Name == productName);

                    currentPerson.AddProduct(currentProduct);
                }

                foreach (var person in people)
                {
                    Console.WriteLine(person);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
