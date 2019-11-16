namespace MilitaryElite.Interfaces
{
    using MilitaryElite.Enums;

    public interface ISpecialisedSoldier : IPrivate
    {
        public Corps Corps { get; }
    }
}
