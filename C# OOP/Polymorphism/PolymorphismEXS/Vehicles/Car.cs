namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double AirConditionerFuel = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += AirConditionerFuel;
        }
    }
}
