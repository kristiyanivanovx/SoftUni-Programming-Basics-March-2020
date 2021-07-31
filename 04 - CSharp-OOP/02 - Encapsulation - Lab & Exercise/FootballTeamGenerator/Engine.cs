using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Engine
    {
        private List<Team> footballTeams;

        public Engine()
        {
            this.footballTeams = new List<Team>();
        }

        public void Run()
        {
            string command = Console.ReadLine();
            while (command != "END")
            {
                try
                {
                    string[] arguments = command.Split(";").ToArray();
                    string firstCommandType = arguments[0];

                    if (firstCommandType == "Team")
                    {
                        AddTeam(arguments);
                    }
                    else if (firstCommandType == "Add")
                    {
                        AddPlayerToTeam(arguments);
                    }
                    else if (firstCommandType == "Remove")
                    {
                        RemovePlayer(arguments);
                    }
                    else if (firstCommandType == "Rating")
                    {
                        PrintRating(arguments);
                    }

                    command = Console.ReadLine();
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    command = Console.ReadLine();

                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void PrintRating(string[] arguments)
        {
            string teamName = arguments[1];
            this.ValidateTeamExists(teamName);

            Team neededTeam = footballTeams.First(t => t.Name == teamName);
            Console.WriteLine(neededTeam);
        }

        private void RemovePlayer(string[] arguments)
        {
            string teamName = arguments[1];
            string playerName = arguments[2];

            this.ValidateTeamExists(teamName);

            Team team = this.footballTeams.First(t => t.Name == teamName);
            team.RemovePlayer(playerName);
        }

        private void AddPlayerToTeam(string[] arguments)
        {
            string teamName = arguments[1];
            string playerName = arguments[2];

            this.ValidateTeamExists(teamName);

            Team team = this.footballTeams.First(t => t.Name == teamName);
            Stats stats = this.CreateStats(arguments.Skip(3).ToArray());
            Player player = new Player(playerName, stats);
            team.AddPlayer(player);
        }

        private Stats CreateStats(string[] statisticsArguments)
        {
            int endurance = int.Parse(statisticsArguments[0]);
            int sprint = int.Parse(statisticsArguments[1]);
            int dribble = int.Parse(statisticsArguments[2]);
            int passing = int.Parse(statisticsArguments[3]);
            int shooting = int.Parse(statisticsArguments[4]);

            Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);
            return stats;
        }

        private void ValidateTeamExists(string teamName)
        {
            if (!this.footballTeams.Any(t => t.Name == teamName))
            {
                string message = string.Format(GlobalConstants.MissingTeamExceptionMessage, teamName);
                throw new ArgumentException(message);
            }
        }

        private void AddTeam(string[] arguments)
        {
            string teamName = arguments[1];
            Team team = new Team(teamName);
            this.footballTeams.Add(team);
        }
    }
}
