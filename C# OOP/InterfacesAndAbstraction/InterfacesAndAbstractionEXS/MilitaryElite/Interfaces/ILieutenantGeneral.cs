namespace MilitaryElite.Interfaces
{
    using System.Collections.Generic;

    public interface ILieutenantGeneral : IPrivate
    {
        public Dictionary<string, IPrivate> Privates { get; }
    }
}
