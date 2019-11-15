namespace Ferrari
{
    public class Ferrari : ICarMoveable
    {
        public Ferrari(string driver)
        {
            this.Driver = driver;
        }

        public string Driver { get; }
        public string Model => "488-Spider";
        public string Break()
        {
            return $"Brakes!";
        }

        public string Gas()
        {
            return $"Gas!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.Break()}/{this.Gas()}/{this.Driver}";
        }
    }
}
