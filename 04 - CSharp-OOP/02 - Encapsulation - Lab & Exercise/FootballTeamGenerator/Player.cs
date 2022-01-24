using System;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;

        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }
        
        public string Name
        {
            get => this.name;
            private set
            {
                EnsureCorrectName(value);
                this.name = value;
            }
        }

        public Stats Stats { get; set; }

        public double OverallSkill => this.Stats.SkillLevel;

        public static void EnsureCorrectName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(GlobalConstants.EmptyNameExceptionMessage);
            }
        }
    }
}
