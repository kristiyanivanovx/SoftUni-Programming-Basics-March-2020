using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using static Gym.Utilities.Messages.ExceptionMessages;
using static Gym.Utilities.Messages.OutputMessages;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        
        public Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Equipment = new List<IEquipment>();
            this.Athletes = new List<IAthlete>();
        }

        public string Name
        {
            get => this.name;
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(InvalidGymName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; }

        public double EquipmentWeight
            => this.Equipment.Sum(x => x.Weight);

        public ICollection<IEquipment> Equipment { get; }
        
        public ICollection<IAthlete> Athletes  { get; }
        
        public void AddAthlete(IAthlete athlete)
        {
            if (this.Athletes.Count >= this.Capacity)
            {
                throw new InvalidOperationException(NotEnoughSize);
            }
            
            this.Athletes.Add(athlete);
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return this.Athletes.Remove(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.Equipment.Add(equipment);
        }

        public void Exercise()
        {
            this.Athletes
                .ToList()
                .ForEach(x => x.Exercise());
        }

        public string GymInfo()
        {
            var sb = new StringBuilder();
            
            var joined = this.Athletes.Any() ? 
                string.Join(", ", this.Athletes.Select(x => x.FullName)) : 
                "No athletes";
            
            sb.AppendLine($"{this.name} is a {this.GetType().Name}:");
            sb.AppendLine($"Athletes: {joined}");
            sb.AppendLine($"Equipment total count: {this.Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {this.EquipmentWeight:f2} grams");

            return sb.ToString().Trim();
        }
    }
}