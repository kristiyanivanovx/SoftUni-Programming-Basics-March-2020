using System;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double AirConditionerModifier = 0.9;

        public Car(double fuelQuantity, double litersPerKM)
            : base(fuelQuantity, litersPerKM)
        {
        }

        public override double FuelConsumption
            => base.FuelConsumption + AirConditionerModifier;
    }
}
