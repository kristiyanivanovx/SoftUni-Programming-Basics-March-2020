using System;
using System.Collections.Generic;
using System.Linq;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using static CarRacing.Utilities.Messages.ExceptionMessages;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> models;

        public IReadOnlyCollection<IRacer> Models
            => this.models.AsReadOnly();

        public RacerRepository()
        {
            this.models = new List<IRacer>();
        }
        
        public void Add(IRacer racer)
        {
            if (racer == null)
            {
                throw new ArgumentException(InvalidAddRacerRepository);
            }
            
            this.models.Add(racer);
        }

        public bool Remove(IRacer racer)
        {
            return this.models.Remove(racer);
        }

        public IRacer FindBy(string property)
        {
            return this.models.FirstOrDefault(x => x.Username == property);
        }
    }
}