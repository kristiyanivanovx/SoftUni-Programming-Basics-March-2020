using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string region,  string breed)
            : base(name, weight, region, breed)
        {
        }

        public override double WeightMultiplier => 0.30;

        public override ICollection<Type> PreferredFoods
        => new List<Type>() { typeof(Vegetable), typeof(Meat) };

        public override string MakeNoice()
        {
            return "Meow";
        }
    }
}
