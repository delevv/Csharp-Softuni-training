using System;
using System.Linq;
using System.Collections.Generic;

namespace ShoppingSpree
{
    class Person
    {
        public string Name { get; set; }
        public double Money{ get; set; }
        public List<string> BagOfProducts { get; set; }

        public Person()
        {
            this.BagOfProducts = new List<string>();
        }
    }
    class Product
    {
        public string Name { get; set; }
        public int Cost { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            string[] personsInfo = Console.ReadLine().Split(";");
            string[] productsInfo = Console.ReadLine().Split(";");

            for (int i = 0; i < personsInfo.Length; i++)
            {
                string[] personInfo = personsInfo[i].Split("=");

                Person person = new Person();
                person.Name = personInfo[0];
                person.Money = int.Parse(personInfo[1]);
                persons.Add(person);
            }
            for (int i = 0; i < productsInfo.Length; i++)
            {
                string[] productInfo = productsInfo[i].Split("=",StringSplitOptions.RemoveEmptyEntries);

                Product product = new Product();
                product.Name = productInfo[0];
                product.Cost = int.Parse(productInfo[1]);
                products.Add(product);
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] purchaseInfo = command.Split();
                string name = purchaseInfo[0];
                string product = purchaseInfo[1];
                double productPrice = 0;

                foreach (var p in products)
                {
                    if (p.Name == product)
                    {
                        productPrice = p.Cost;
                    }
                }
                foreach (var person in persons)
                {
                    if (person.Name == name)
                    {
                        if (person.Money - productPrice >= 0)
                        {
                            person.Money -= productPrice;
                            person.BagOfProducts.Add(product);
                            Console.WriteLine($"{person.Name} bought {product}");
                        }
                        else
                        {
                            Console.WriteLine($"{person.Name} can't afford {product}");
                        }
                    }
                }
            }
            foreach (var person in persons)
            {
                if (person.BagOfProducts.Count > 0)
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ",person.BagOfProducts)}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
    }
}
