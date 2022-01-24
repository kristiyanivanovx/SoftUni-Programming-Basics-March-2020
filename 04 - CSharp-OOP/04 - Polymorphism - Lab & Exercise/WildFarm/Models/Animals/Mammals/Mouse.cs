using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string region)
            : base(name, weight, region)
        {
        }

        public override double WeightMultiplier => 0.10;

        public override ICollection<Type> PreferredFoods
        {
            get 
            {
               return new List<Type>() { typeof(Vegetable), typeof(Fruit) };
            }
        }

        public override string MakeNoice()
        {
            return "Squeak";
        }
    }
}
