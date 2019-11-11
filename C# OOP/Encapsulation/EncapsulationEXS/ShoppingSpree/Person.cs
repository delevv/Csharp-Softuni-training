using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;

        private decimal money;
        
        private List<Product> bag;
        public Person(string name, decimal money)
        {
            this.bag = new List<Product>();
            this.Name = name;
            this.Money = money;
        }   
        public List<Product> MyProperty
        {
            get 
            {
                return this.bag; 
            }
            private set
            {
                this.bag = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public decimal Money
        {
            get
            {
                return this.money;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }
                else
                {
                    this.money = value;
                }  
            }
        }

        public void AddProduct(Product product)
        {
            if (this.Money - product.Cost >= 0)
            {
                this.bag.Add(product);
                this.Money -= product.Cost;
                
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            if (this.bag.Count == 0)
            {
                return $"{this.name} - Nothing bought";
            }

            return $"{this.name} - {string.Join(", ",this.bag.Select(p=>p.Name))}";
        }
    }
}
