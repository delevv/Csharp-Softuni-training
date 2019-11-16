namespace MilitaryElite.Models
{
    using MilitaryElite.Interfaces;
    using System.Collections.Generic;
    using System.Text;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, Dictionary<string, IPrivate> privates)
            : base(firstName, lastName, id, salary)
        {
            this.Privates = privates;
        }

        public Dictionary<string, IPrivate> Privates { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (var currentPrivate in this.Privates)
            {
                sb.AppendLine("  " + currentPrivate.Value.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
