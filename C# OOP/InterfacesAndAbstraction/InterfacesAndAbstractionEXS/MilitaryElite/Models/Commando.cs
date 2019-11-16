namespace MilitaryElite.Models
{
    using MilitaryElite.Interfaces;
    using MilitaryElite.Enums;
    using System.Text;
    using System.Collections.Generic;

    public class Commando : SpecialisedSoldier,ICommando
    {
        public Commando(string firstName, string lastName, string id, decimal salary, Corps corps, ICollection<IMission> missions) 
            : base(firstName, lastName, id, salary, corps)
        {
            this.Missions = missions;
        }

        public ICollection<IMission> Missions { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Missions:");

            foreach (var currentMission in this.Missions)
            {
                sb.AppendLine("  " + currentMission.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
