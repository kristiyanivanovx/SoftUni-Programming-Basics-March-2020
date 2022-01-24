using WildFarm.Animals;
using WildFarm.Models.Animals.Interfaces;

namespace WildFarm.Models.Animals.Birds
{
    public abstract class Bird : Animal, IBird
    {
        protected Bird(string name, double weigth, double wingSize)
            : base(name, weigth)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";

        }
    }
}
