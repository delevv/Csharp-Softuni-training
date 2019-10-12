using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    class Car
    {

        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        public void Drive(double distance)
        {
            if (this.FuelQuantity - distance/100 * this.FuelConsumption >= 0)
            {
                this.FuelQuantity -= distance /100 * this.FuelConsumption;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }
        public string WhoAmI()
        {
            var result = new StringBuilder();

            result.AppendLine($"Make: {this.Make}");
            result.AppendLine($"Model: {this.Model}");
            result.AppendLine($"Year: {this.Year}");
            result.Append($"Fuel: {this.FuelQuantity:F2}L");

            return result.ToString();
        }
    }
}
