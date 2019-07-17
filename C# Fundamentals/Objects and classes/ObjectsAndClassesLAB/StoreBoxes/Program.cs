using System;
using System.Linq;
using System.Collections.Generic;

//Class
namespace StoreBoxes
{
    class Box
    {


        public string SerialNumber { get; set; }
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }
        public double PriceForBox { get; set; }
        public double TotalPrice { get; set; }
    }
}

//Main
namespace StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> itemBoxes = new List<Box>();
            double totalPrice = 0;

            string command;
            while ((command=Console.ReadLine())!="end")
            {
                string[] parts = command.Split();

                string serialNumber = parts[0];
                string itemName = parts[1];
                int itemQuantity = int.Parse(parts[2]);
                double itemPrice = double.Parse(parts[3]);

                totalPrice = itemPrice * itemQuantity;

                Box box = new Box();

                box.SerialNumber = serialNumber;
                box.ItemName = itemName;
                box.ItemQuantity = itemQuantity;
                box.PriceForBox = itemPrice;
                box.TotalPrice = itemPrice * itemQuantity;

                itemBoxes.Add(box);
            }

            List<Box> sortedBox = itemBoxes.OrderBy(boxes => boxes.TotalPrice).ToList();
            sortedBox.Reverse();

            foreach (Box box in sortedBox)
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.ItemName} - ${box.PriceForBox:F2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.TotalPrice:F2}");

            }
        }
    }
}