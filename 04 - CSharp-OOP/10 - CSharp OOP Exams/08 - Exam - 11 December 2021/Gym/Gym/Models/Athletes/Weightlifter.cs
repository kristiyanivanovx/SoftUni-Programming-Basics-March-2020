using System;
using static Gym.Utilities.Messages.ExceptionMessages;
using static Gym.Utilities.Messages.OutputMessages;

namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        public Weightlifter(string fullName, string motivation, int numberOfMedals)
            : base (fullName, motivation, numberOfMedals, 50)
        {
            
        }

        public override void Exercise()
        {
            this.Stamina += 10;

            if (this.Stamina > 100)
            {
                this.Stamina = 100;

                throw new ArgumentException(InvalidStamina);
            }
        }
    }
}