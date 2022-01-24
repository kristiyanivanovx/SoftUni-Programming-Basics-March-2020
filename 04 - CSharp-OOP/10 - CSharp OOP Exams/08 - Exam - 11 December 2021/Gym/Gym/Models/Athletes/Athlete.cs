using System;
using Gym.Models.Athletes.Contracts;
using static Gym.Utilities.Messages.ExceptionMessages;
using static Gym.Utilities.Messages.OutputMessages;

namespace Gym.Models.Athletes
{
    public abstract class Athlete : IAthlete
    {
        private string fullName;
        private string motivation;
        private int numberOfMedals;
        
        public Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            this.FullName = fullName;
            this.Motivation = motivation;
            this.NumberOfMedals = numberOfMedals;
            this.Stamina = stamina;
        }

        public string FullName
        {
            get => this.fullName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(InvalidAthleteName);
                }

                this.fullName = value;
            }
        }

        public string Motivation
        {
            get => this.motivation;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(InvalidAthleteMotivation);
                }

                this.motivation = value;
            }
        }
        
        public int Stamina { get; protected set; }

        public int NumberOfMedals
        {
            get => this.numberOfMedals;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(InvalidAthleteMedals);
                }

                this.numberOfMedals = value;
            }
        }

        public abstract void Exercise();
    }
}