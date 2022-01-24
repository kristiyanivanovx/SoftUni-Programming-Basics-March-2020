using System.Linq;
using System.Collections.Generic;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> cars;

        public CarRepository()
        {
            this.cars = new List<ICar>();
        }

        public void Add(ICar driver)
            => this.cars.Add(driver);

        public IReadOnlyCollection<ICar> GetAll()
            => this.cars.AsReadOnly();

        public ICar GetByName(string model)
            => this.cars.FirstOrDefault(x => x.Model == model);

        public bool Remove(ICar car)
            => this.cars.Remove(car);
    }
}
