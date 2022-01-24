using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamworkProjects
{
    class User
    {
        public User(string name)
        {
            this.Name = name;
        }
        
        public string Name { get; set; }

        public bool HasTeam { get; set; }
    }

    class Team
    {
        public Team(string name, User captain)
        {
            this.Name = name;
            this.Captain = captain;
            this.Members = new List<User>();
        }

        public User Captain { get; set; }
        public string Name { get; set; }
        public List<User> Members { get; set; }
    }

    class Program
    {

        static void Main(string[] args)
        {
            List<Team> toBeDisbandend = new List<Team>();
            List<Team> teams = new List<Team>();

            int value = int.Parse(Console.ReadLine());
            for (int i = 0; i < value; i++)
            {
                string[] data = Console.ReadLine().Split("-");
                string userName = data[0];
                string teamName = data[1];

                if (teams.Any(x => x.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (teams.Any(x => x.Captain.Name == userName))
                {
                    Console.WriteLine($"{userName} cannot create another team!");
                }
                else
                {
                    User user = new User(data[0]);
                    Team team = new Team(data[1], user);
                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {user.Name}!");
                }
            }

            string command = Console.ReadLine();
            while (!command.Contains("end of assignment"))
            {
                string[] data = command.Split("->");
                string userName = data[0];
                string teamName = data[1];

                if (!teams.Any(x => x.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (teams.Any(x => x.Captain.Name == userName) ||
                         teams.Any(x => x.Members.Any(x => x.Name == userName)))
                {
                    Console.WriteLine($"Member {userName} cannot join team {teamName}!");
                }
                else
                {
                    User user = new User(userName);
                    Team team = teams.FirstOrDefault(x => x.Name == teamName);
                    team.Members.Add(user);
                }

                command = Console.ReadLine();
            }

            teams = teams.OrderByDescending(x => x.Name).ToList();
            teams.ForEach(x =>
            {
                if (x.Members.Count > 0)
                {
                    Console.WriteLine(x.Name);
                    Console.WriteLine("- " + x.Captain.Name);
                    x.Members.ForEach(x =>
                    {
                        Console.WriteLine("-- " + x.Name);
                    });
                }
                else
                {
                    toBeDisbandend.Add(x);
                }
            });

            Console.WriteLine($"Teams to disband:");
            toBeDisbandend.ForEach(x =>
            {
                Console.WriteLine(x.Name);
            });
        }
    }
}
