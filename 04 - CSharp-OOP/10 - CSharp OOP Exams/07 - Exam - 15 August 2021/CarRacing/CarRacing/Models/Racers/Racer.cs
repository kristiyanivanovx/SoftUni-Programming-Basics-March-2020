using System;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using static CarRacing.Utilities.Messages.ExceptionMessages;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        private string username;
        private string racingBehavior;
        private int drivingExperience;
        private ICar car;
        
        public string Username
        {
            get => this.username;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidRacerName);
                }

                this.username = value;
            }
        }
        
        public string RacingBehavior
        {
            get => this.racingBehavior;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidRacerBehavior);
                }

                this.racingBehavior = value;
            }
        }
        
        public int DrivingExperience 
        {
            get => this.drivingExperience;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(InvalidRacerDrivingExperience);
                }

                this.drivingExperience = value;
            }
        }
        
        public ICar Car 
        {
            get => this.car;
            set
            {
                if (value == null)
                {
                    throw new ArgumentException(InvalidRacerCar);
                }

                this.car = value;
            }
        }

        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            this.Username = username;
            this.RacingBehavior = racingBehavior;
            this.DrivingExperience = drivingExperience;
            this.Car = car;
        }

        public virtual void Race() 
            => this.car.Drive();

        public bool IsAvailable()
            => this.car.FuelAvailable >= this.car.FuelConsumptionPerRace;

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Username}" + Environment.NewLine +
                   $"--Driving behavior: {this.RacingBehavior}" + Environment.NewLine +
                   $"--Driving experience: {this.DrivingExperience}" + Environment.NewLine +
                   $"--Car: {this.Car.Make} {this.Car.Model} ({this.Car.VIN})";

        }
    }
}