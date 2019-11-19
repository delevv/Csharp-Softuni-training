namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double AirConditionerFuel = 1.4;
        
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.IsEmpty = true;
        }

        public bool IsEmpty { get; set; }

        public override string Drive(double distance)
        {
            var currentConsumption = this.FuelConsumption;

            if (!IsEmpty)
            {
                currentConsumption += AirConditionerFuel;
            }
            
            var neededFuel = distance * currentConsumption;

            if (this.FuelQuantity - neededFuel >= 0)
            {
                this.FuelQuantity -= neededFuel;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }
    }
}
