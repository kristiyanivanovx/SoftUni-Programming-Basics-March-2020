using System.Collections.Generic;

namespace MilitaryElite.Interfaces
{
    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<ISoldier> Privates { get; }

        void AddPrivate(ISoldier privateSoldier);
    }
}
