using System;

namespace FootballTeamGenerator
{
    public class Stats
    {
        public const int LowerBoundaryStat = 0;
        public const int UpperBoundaryStat = 100;
        public const double StatsCount = 5.0;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                EnsureCorrectStat(value, nameof(Endurance));
                this.endurance = value;
            }
        }

        public int Sprint
        {
            get => this.sprint;
            private set
            {
                EnsureCorrectStat(value, nameof(Sprint));
                this.sprint = value;
            }
        }

        public int Dribble
        {
            get => this.dribble;
            private set
            {
                EnsureCorrectStat(value, nameof(Dribble));
                this.dribble = value;
            }
        }

        public int Passing
        {
            get => this.passing;
            private set
            {
                EnsureCorrectStat(value, nameof(Passing));
                this.passing = value;
            }
        }

        public int Shooting
        {
            get => this.shooting;
            private set
            {
                EnsureCorrectStat(value, nameof(Shooting));
                this.shooting = value;
            }
        }

        public double SkillLevel => (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / StatsCount;

        public static void EnsureCorrectStat(int statValue, string statName)
        {
            if (statValue < LowerBoundaryStat || statValue > UpperBoundaryStat)
            {
                string message = string.Format(GlobalConstants.InvalidStatExceptionMessage, statName, LowerBoundaryStat, UpperBoundaryStat);
                throw new ArgumentException(message);
            }
        }
    }
}
