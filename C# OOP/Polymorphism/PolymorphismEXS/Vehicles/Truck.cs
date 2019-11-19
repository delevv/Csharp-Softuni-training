namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double AirConditionerFuel = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += AirConditionerFuel;
        }

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel*0.95);
        }
    }
}
