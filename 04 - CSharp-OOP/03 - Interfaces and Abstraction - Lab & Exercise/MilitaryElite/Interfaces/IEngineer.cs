using MilitaryElite.Classes;
using System.Collections.Generic;

namespace MilitaryElite.Interfaces
{
    public interface IEngineer : ISpecialisedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs { get; }

        void AddRepair(IRepair repair);
    }
}
