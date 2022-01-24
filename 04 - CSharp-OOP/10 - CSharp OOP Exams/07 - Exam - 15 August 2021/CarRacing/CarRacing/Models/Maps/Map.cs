using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using static CarRacing.Utilities.Messages.ExceptionMessages;
using static CarRacing.Utilities.Messages.OutputMessages;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerTwo.IsAvailable() && !racerOne.IsAvailable())
            {
                return RaceCannotBeCompleted;
            }

            if (!racerOne.IsAvailable()) //&& racerTwo.IsAvailable()
            {
                // racerTwo wins
                return string.Format(OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            
            if (!racerTwo.IsAvailable()) // && racerOne.IsAvailable()
            {
                // racerOne wins
                return string.Format(OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            
            racerOne.Race();
            racerTwo.Race();
            
            var strictMultiplier = 1.2;
            var aggressiveMultiplier = 1.1;

            double chanceOfWinningRacerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience ;
            if (racerOne.RacingBehavior == "strict")
            {
                chanceOfWinningRacerOne *= strictMultiplier;
            }
            else  if (racerOne.RacingBehavior == "aggressive")
            {
                chanceOfWinningRacerOne *= aggressiveMultiplier;
            }

            double chanceOfWinningRacerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience ;
            if (racerTwo.RacingBehavior == "strict")
            {
                chanceOfWinningRacerTwo *= strictMultiplier;
            }
            else  if (racerTwo.RacingBehavior == "aggressive")
            {
                chanceOfWinningRacerTwo *= aggressiveMultiplier;
            }

            if (chanceOfWinningRacerOne > chanceOfWinningRacerTwo)
            {
                return string.Format(RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
            }
            
            return string.Format(RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
        }

    }
}