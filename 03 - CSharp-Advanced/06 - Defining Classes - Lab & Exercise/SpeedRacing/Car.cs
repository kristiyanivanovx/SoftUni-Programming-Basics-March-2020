using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        //private string model;
        //private double fuelAmount;
        //private double fuelConsumptionPerKilometer;
        //private double travelledDistance;

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            //this.TravelledDistance = 0;
        }

        public bool Drive(double distanceTraveled) 
        {
            double neededFuel = distanceTraveled * this.FuelConsumptionPerKilometer;

            if (neededFuel > this.FuelAmount)
            {
                return false;
            }

            this.FuelAmount -= neededFuel;
            this.TravelledDistance += distanceTraveled;

            return true;
        } 
    }
}
