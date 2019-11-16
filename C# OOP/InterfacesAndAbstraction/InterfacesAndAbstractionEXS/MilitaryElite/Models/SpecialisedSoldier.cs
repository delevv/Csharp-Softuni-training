namespace MilitaryElite.Models
{
    using MilitaryElite.Enums;
    using MilitaryElite.Interfaces;

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string firstName, string lastName, string id, decimal salary,Corps corps)
            : base(firstName, lastName, id, salary)
        {
            this.Corps = corps;
        }

        public Corps Corps { get; }
    }
}
