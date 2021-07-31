using System;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IDriveable, IRefuelable
    {
        protected Vehicle(double fuelQuantity, double litersPerKM)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = litersPerKM;
        }

        public double FuelQuantity { get; set; }

        public virtual double FuelConsumption { get; }

        public void Drive(double distance)
        {
            var litersNeeded = distance * this.FuelConsumption;

            if (this.FuelQuantity < litersNeeded)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= litersNeeded;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }

            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
