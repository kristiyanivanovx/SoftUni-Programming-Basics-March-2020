using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite.Classes
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private ICollection<ISoldier> privates;

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<ISoldier>();
        }

        public IReadOnlyCollection<ISoldier> Privates
            => (IReadOnlyCollection<ISoldier>) this.privates;

        public void AddPrivate(ISoldier privateSoldier)
        {
            this.privates.Add(privateSoldier);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString())
              .AppendLine($"Privates:");
            
            foreach (var @private in this.privates)
            {
                sb.AppendLine("  " + @private.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
