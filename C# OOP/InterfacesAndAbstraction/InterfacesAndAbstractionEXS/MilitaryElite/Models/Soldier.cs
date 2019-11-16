namespace MilitaryElite.Models
{
    using MilitaryElite.Interfaces;
    public class Soldier : ISoldier
    {
        public Soldier(string firstName, string lastName, string id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public string Id { get; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}";
        }
    }
}
