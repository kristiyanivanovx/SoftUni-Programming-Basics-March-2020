using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string region, string breed)
            : base(name, weight, region, breed)
        {
        }

        public override double WeightMultiplier => 1.00;

        public override ICollection<Type> PreferredFoods
            => new List<Type>() { typeof(Meat)};

        public override string MakeNoice()
        {
            return "ROAR!!!";
        }
    }
}
