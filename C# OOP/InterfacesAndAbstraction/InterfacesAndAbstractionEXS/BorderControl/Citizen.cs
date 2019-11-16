namespace BorderControl
{
    public class Citizen : IId
    {
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public string Name { get; }

        public int Age { get; set; }
        
        public string Id { get; }
    }
}
