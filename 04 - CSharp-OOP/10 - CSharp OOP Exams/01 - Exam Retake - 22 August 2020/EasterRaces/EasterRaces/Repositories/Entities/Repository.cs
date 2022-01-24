using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class Repository<T> : IRepository<T>
    {
        private readonly List<T> models;

        public Repository()
        {
            this.models = new List<T>();
        }

        public void Add(T model)
            => this.models.Add(model);

        public IReadOnlyCollection<T> GetAll()
            => this.models.AsReadOnly();

        public T GetByName(string name)
        {
            throw new NotImplementedException();
            //var needed = this.models.Where(x => x.);
            //return asd;
        }

        public bool Remove(T model)
            => this.models.Remove(model);
    }
}
