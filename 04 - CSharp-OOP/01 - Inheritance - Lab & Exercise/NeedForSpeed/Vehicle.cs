using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private double defaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public int HorsePower { get; set; }

        public double Fuel { get; set; }

        public virtual double DefaultFuelConsumption 
        {
            get => this.defaultFuelConsumption;

            protected set 
            {
                this.defaultFuelConsumption = value;
            } 
        }

        public virtual double FuelConsumption { get; set; }

        public virtual void Drive(double kilometers)
        {
            // kilometers * consumption
            this.Fuel -= (defaultFuelConsumption + FuelConsumption) * kilometers;
        }
    }
}
