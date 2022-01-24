using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using static CarRacing.Utilities.Messages.ExceptionMessages;
using static CarRacing.Utilities.Messages.OutputMessages;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> models;

        public IReadOnlyCollection<ICar> Models
            => this.models.AsReadOnly();

        public CarRepository()
        {
            this.models = new List<ICar>();
        }
        public void Add(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentException(InvalidAddCarRepository);
            }
            
            this.models.Add(car);
        }
        
        public bool Remove(ICar car)
        {
            return this.models.Remove(car);
        }

        public ICar FindBy(string property)
        {
            return this.models.FirstOrDefault(x => x.VIN == property);
        }
    }
}