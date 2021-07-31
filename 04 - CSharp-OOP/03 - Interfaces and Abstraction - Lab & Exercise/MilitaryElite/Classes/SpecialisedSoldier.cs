using System;
using MilitaryElite.Enumerations;
using MilitaryElite.Exceptions;

namespace MilitaryElite.Classes
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = TryParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        private Corps TryParseCorps(string corpsString)
        {
            bool parsed = Enum.TryParse(corpsString, out Corps corps);

            if (parsed)
            {
                return corps;
            }

            throw new InvalidCorpsException();
        }
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {this.Corps}";
        }
    }
}
 