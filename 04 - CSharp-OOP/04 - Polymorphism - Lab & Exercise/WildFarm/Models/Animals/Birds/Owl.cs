using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Birds
{
    public class Owl : Bird
    {
        public Owl(string name, double weigth, double wingSize)
            : base(name, weigth, wingSize)
        {
        }

        public override double WeightMultiplier => 0.25;

        public override ICollection<Type> PreferredFoods
            => new List<Type>() { typeof(Meat) };

        public override string MakeNoice()
        {
            return "Hoot Hoot";
        }
    }
}
