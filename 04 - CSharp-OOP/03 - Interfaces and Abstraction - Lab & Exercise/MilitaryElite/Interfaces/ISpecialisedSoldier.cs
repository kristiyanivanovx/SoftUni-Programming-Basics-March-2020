using MilitaryElite.Enumerations;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Classes
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}