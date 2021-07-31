using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;

        private double cubicCentimeters;

        private int minHorsePower;
        private int maxHorsePower;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;

            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, model, value));
                }

                this.model = value;
            }
        }

        public int HorsePower
        {
            get
            {
                return horsePower;
            }
            set
            {
                if (value < this.minHorsePower || value > this.maxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));

                }

                this.horsePower = value;
            }
        }

        public double CubicCentimeters
        {
            get
            {
                return this.cubicCentimeters;
            }
            set
            {
                this.cubicCentimeters = value;
            }
        }

        public double CalculateRacePoints(int laps)
            => this.cubicCentimeters / this.horsePower * laps;
    }
}
