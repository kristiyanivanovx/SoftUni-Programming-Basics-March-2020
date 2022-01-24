using System;
using System.Collections.Generic;
using System.Linq;
using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using static Gym.Utilities.Messages.ExceptionMessages;
using static Gym.Utilities.Messages.OutputMessages;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private ICollection<IGym> gyms;

        public Controller()
        {
            this.equipment = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }
        
        public string AddGym(string gymType, string gymName)
        {
            IGym gym;
            if (gymType == nameof(BoxingGym))
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == nameof(WeightliftingGym))
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException(InvalidGymType);
            }
            
            this.gyms.Add(gym);
            return string.Format(SuccessfullyAdded, gymType);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment;
            if (equipmentType == nameof(BoxingGloves))
            {
                equipment = new BoxingGloves();
            }
            else if (equipmentType == nameof(Kettlebell))
            {
                equipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException(InvalidEquipmentType);
            }
            
            this.equipment.Add(equipment);
            return string.Format(SuccessfullyAdded, equipmentType);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            var equipment = this.equipment.FindByType(equipmentType);
            if (equipment == null)
            {
                throw new InvalidOperationException(string.Format(InexistentEquipment, equipmentType));
            }
            
            var gym = this.gyms.First(x => x.Name == gymName);

            gym.AddEquipment(equipment);
            this.equipment.Remove(equipment);

            return string.Format(EntityAddedToGym, equipmentType, gymName);
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete;
            IGym gym = this.gyms.First(x => x.Name == gymName);
            
            if (athleteType == nameof(Boxer))
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
                
            }
            else if (athleteType == nameof(Weightlifter))
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException(InvalidAthleteType);
            }

            var notAppropriateForBoxer =
                !(gym.GetType().Name == nameof(BoxingGym) && athleteType == nameof(Boxer));
            
            var notAppropriateForWeightlifter =
                !(gym.GetType().Name == nameof(WeightliftingGym) && athleteType == nameof(Weightlifter));

            if (notAppropriateForBoxer && notAppropriateForWeightlifter)
            {
                return InappropriateGym;
            }
            
            gym.AddAthlete(athlete);
            return string.Format(EntityAddedToGym, athleteType, gymName);
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = this.gyms.First(x => x.Name == gymName);
            gym.Exercise();

            return string.Format(AthleteExercise, gym.Athletes.Count);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = this.gyms.First(x => x.Name == gymName);
            return string.Format(EquipmentTotalWeight, gymName, gym.EquipmentWeight);
        }

        public string Report()
        {
            return string.Join(Environment.NewLine, this.gyms.Select(x => x.GymInfo()));
        }
    }
}