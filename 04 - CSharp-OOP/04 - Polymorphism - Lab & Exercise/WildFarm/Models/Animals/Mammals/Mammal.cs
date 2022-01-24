using WildFarm.Animals;
using WildFarm.Models.Animals.Interfaces;

namespace WildFarm.Models.Animals.Mammals
{
    public abstract class Mammal : Animal, IMammal
    {
        protected Mammal(string name, double weight, string region)
            : base(name, weight)
        {
            this.LivingRegion = region;
        }

        public string LivingRegion { get; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
