namespace MilitaryElite.Models
{
    using MilitaryElite.Interfaces;
    using System;

    public class Spy : Soldier, ISpy
    {
        public Spy(string firstName, string lastName, string id,int codeNumber)
            : base(firstName, lastName, id)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; }

        public override string ToString()
        {
            return base.ToString()
                    + Environment.NewLine +
                   $"Code Number: {this.CodeNumber}";
        }
    }
}
