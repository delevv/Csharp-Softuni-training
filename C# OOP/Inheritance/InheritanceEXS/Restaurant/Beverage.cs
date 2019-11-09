namespace Restaurant
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price,double mililiters) 
            : base(name, price)
        {
            this.Milliliters = mililiters;
        }

        public double Milliliters { get; set; }
    }
}
