using System;
using System.Linq;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class Team 
    {
        private const int LowerBoundaryStat = 0;
        private const int UpperBoundaryStat = 100;

        private string name;
        private List<Player> teamCrew;

        private Team()
        { 
            this.teamCrew = new List<Player>();
        }

        public Team(string name)
            : this()
        {
            this.Name = name;
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

        public int Rating 
        {
            get
            {
                if (this.teamCrew.Count > 0)
                {
                    return (int) Math.Round(this.teamCrew.Average(p => p.OverallSkill));
                }

                return 0;
            } 
        }

        public void AddPlayer(Player player) 
        {
            this.teamCrew.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            if (!this.teamCrew.Any(p => p.Name == playerName))
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team. ");
            }

            Player player = this.teamCrew.FirstOrDefault(p => p.Name == playerName);
            this.teamCrew.Remove(player);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }

        public static void EnsureCorrectName(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(GlobalConstants.EmptyNameExceptionMessage);
            }
        }

        public static void EnsureCorrectStat(int statValue, string statName)
        {
            if (statValue < LowerBoundaryStat || statValue > UpperBoundaryStat)
            {
                throw new ArgumentException($"{statName} should be between {LowerBoundaryStat} and {UpperBoundaryStat}.");
            }
        }
    }
}
