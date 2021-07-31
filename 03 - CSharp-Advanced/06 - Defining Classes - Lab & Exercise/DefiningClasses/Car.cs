using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class Car
    {
        private string make;

        private string model;

        private int year;

        private double fuelQuantity;

        private double fuelConsumption;

        public Car(string make, string model, int year)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity,
            double fuelConsumption, Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public Engine Engine { get; set; }

        public Tire[] Tires { get; set; }

        public void Drive(double distance)
        {
            if ((this.fuelQuantity - this.fuelConsumption) > 0)
            {
                Console.WriteLine("Driiiive! Vroom!");
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            return $"Make: {this.Make}\n" +
                   $"Model: {this.Model}\n" +
                   $"Year: {this.Year}\n" +
                   $"Fuel: {this.FuelQuantity:F2}L";
        }
    }
}
