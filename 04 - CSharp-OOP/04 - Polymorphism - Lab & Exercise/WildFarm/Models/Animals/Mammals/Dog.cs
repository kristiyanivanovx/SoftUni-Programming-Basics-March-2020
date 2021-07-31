using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals
{
    public class Dog : Mammal
    {
        //Dog Doncho 500 Street 
        //[{AnimalName}, {AnimalWeight}, {AnimalLivingRegion}, {FoodEaten}]"

        public Dog(string name, double weight, string region)
            : base(name, weight, region)
        {
        }

        public override double WeightMultiplier => 0.40;

        public override ICollection<Type> PreferredFoods
            => new List<Type>() { typeof(Meat) };

        public override string MakeNoice()
        {
            return "Woof!";
        }
    }
}
