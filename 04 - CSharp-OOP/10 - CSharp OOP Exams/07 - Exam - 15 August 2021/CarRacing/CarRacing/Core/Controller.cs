using System;
using System.Linq;
using System.Text;
using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Repositories;
using static CarRacing.Utilities.Messages.ExceptionMessages;
using static CarRacing.Utilities.Messages.OutputMessages;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;

        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            Car car = null;
            if (type == "SuperCar")
            {
                car = new SuperCar(make, model, VIN, horsePower);
            } 
            else if (type == "TunedCar")
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            else
            {
               throw new ArgumentException(InvalidCarType);
            }
            
            this.cars.Add(car);
            return string.Format(SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            Racer racer = null;
            var car = this.cars.FindBy(carVIN);
            
            if (car == null)
            {
                throw new ArgumentException(CarCannotBeFound);
            }
            
            if (type == "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(username, car);
            } 
            else if (type == "StreetRacer")
            {
                racer = new StreetRacer(username, car);
            }
            else
            {
                throw new ArgumentException(InvalidRacerType);
            }
            
            this.racers.Add(racer);
            return string.Format(SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            var racerOne = this.racers.FindBy(racerOneUsername);
            var racerTwo = this.racers.FindBy(racerTwoUsername);

            if (racerOne == null)
            {
                throw new ArgumentException(string.Format(RacerCannotBeFound, racerOneUsername));
            }
            
            if (racerTwo == null)
            {
                throw new ArgumentException(string.Format(RacerCannotBeFound, racerTwoUsername));
            }
            
            return this.map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            var orderedRacers = this.racers.Models
                .OrderByDescending(x => x.DrivingExperience)
                .ThenBy(x => x.Username);

            foreach (var racer in orderedRacers)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}