namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;
    using MilitaryElite.Enums;
    using MilitaryElite.Interfaces;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string firstName, string lastName, string id, decimal salary, Corps corps,ICollection<IRepair> repairs) 
            : base(firstName, lastName, id, salary, corps)
        {
            this.Repairs = repairs;
        }

        public ICollection<IRepair> Repairs { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Repairs:");

            foreach (var currentRepair in this.Repairs)
            {
                sb.AppendLine("  " + currentRepair.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
