namespace MilitaryElite.Interfaces
{
    using System.Collections.Generic;

    interface ICommando : ISpecialisedSoldier
    {
        public ICollection<IMission> Missions { get; }
    }
}
