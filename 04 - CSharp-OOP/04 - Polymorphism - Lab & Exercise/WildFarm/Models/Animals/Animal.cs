using System;
using System.Collections.Generic;
using WildFarm.Models.Animals.Interfaces;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Animals
{
    public abstract class Animal : IAnimal, IFeedable, INoiceable
    {
        protected Animal(string name, double weigth)
        {
            this.Name = name;
            this.Weight = weigth;
        }

        public string Name { get; }
        
        public double Weight { get; private set; }
        
        public int FoodEaten { get; private set; }

        public abstract double WeightMultiplier { get; }

        public abstract ICollection<Type> PreferredFoods { get; }

        public void Feed(IFood food)
        {
            if (!this.PreferredFoods.Contains(food.GetType()))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * WeightMultiplier;
        }

        public abstract string MakeNoice();

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}]";
        }
    }
}
