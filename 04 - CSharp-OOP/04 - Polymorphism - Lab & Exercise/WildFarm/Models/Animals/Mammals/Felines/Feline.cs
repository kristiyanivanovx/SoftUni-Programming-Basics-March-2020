using WildFarm.Models.Animals.Interfaces;

namespace WildFarm.Models.Animals.Mammals.Felines
{
    public abstract class Feline : Mammal, IFeline
    {
        protected Feline(string name, double weight, string region, string breed)
            : base(name, weight, region)
        {
            this.Breed = breed;
        }

        public string Breed { get; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
