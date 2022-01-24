using System;
using CarRacing.Models.Cars.Contracts;
using static CarRacing.Utilities.Messages.ExceptionMessages;

namespace CarRacing.Models.Cars
{
    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelAvailable;
        private double fuelConsumptionPerRace;

        public Car(string make, string model, string VIN, 
            int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            this.Make = make;
            this.Model = model;
            this.VIN = VIN;
            this.HorsePower = horsePower;
            this.FuelAvailable = fuelAvailable;
            this.FuelConsumptionPerRace = fuelConsumptionPerRace;
        }
        
        public string Make
        {
            get => this.make;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidCarMake);
                }

                this.make = value;
            }
        }

        public string Model
        {
            get => this.model;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidCarModel);
                }

                this.model = value;
            }
        }
        
        public string VIN
        {
            get => this.vin;
            set
            {
                if (value.Length != 17)
                {
                    throw new ArgumentException(InvalidCarVIN);
                }

                this.vin = value;
            }
        }
        
        public int HorsePower
        {
            get => this.horsePower;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(InvalidCarHorsePower);
                }

                this.horsePower = value;
            }
        }

        public double FuelAvailable
        {
            get => this.fuelAvailable;
            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.fuelAvailable = value;
            }
        }

        public double FuelConsumptionPerRace
        {
            get => this.fuelConsumptionPerRace;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(InvalidCarFuelConsumption);
                }

                this.fuelConsumptionPerRace = value;
            }
        }
        
        public virtual void Drive()
        {
            fuelAvailable -= fuelConsumptionPerRace;
        }
    }
}