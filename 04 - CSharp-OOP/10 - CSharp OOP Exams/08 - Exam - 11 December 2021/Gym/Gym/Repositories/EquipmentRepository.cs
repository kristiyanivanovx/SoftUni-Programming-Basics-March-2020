using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;

namespace Gym.Repositories
{
    public class EquipmentRepository :IRepository<IEquipment>
    {
        private readonly List<IEquipment> models;

        public IReadOnlyCollection<IEquipment> Models
            => this.models.AsReadOnly();

        public EquipmentRepository()
        {
            this.models = new List<IEquipment>();
        }
        
        public void Add(IEquipment model)
        {
            this.models.Add(model);
        }

        public bool Remove(IEquipment model)
        {
            return this.models.Remove(model);
        }

        public IEquipment FindByType(string type)
        {
            return this.models.FirstOrDefault(x => x.GetType().Name == type);
        }
    }
}