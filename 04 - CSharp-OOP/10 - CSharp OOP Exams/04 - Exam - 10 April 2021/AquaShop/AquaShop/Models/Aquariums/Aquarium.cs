using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private readonly List<IDecoration> decorations;
        private readonly List<IFish> fish;

        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }

        public string Name
        {
            // unque names
            get => this.name;
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                this.capacity = value;
            }
        }

        public ICollection<IDecoration> Decorations 
            => this.decorations.AsReadOnly();
        
        public ICollection<IFish> Fish
            => this.fish.AsReadOnly();

        public int Comfort 
            => this.Decorations.Sum(x => x.Comfort);

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.Fish.Count() >= this.capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.fish.Add(fish);
            this.Capacity++;
        }

        public void Feed()
        {
            foreach (IFish fish in Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} ({this.GetType().Name})")
              .AppendLine("Fish: " + (string.Join(", ", this.Fish) ?? "none"))
              .AppendLine("Decorations: " + this.decorations.Count())
              .AppendLine("Comfort: " + this.Comfort);

            return sb.ToString().Trim();
        }

        public bool RemoveFish(IFish fish)
            => this.fish.Remove(fish);
    }
}
