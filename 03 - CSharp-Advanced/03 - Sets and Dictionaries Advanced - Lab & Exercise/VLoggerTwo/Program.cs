using System;
using System.Collections.Generic;
using System.Linq;

namespace VLoggerTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> app = new Dictionary<string, Dictionary<string, SortedSet<string>>>();
            string command = Console.ReadLine();

            while (command != "Statistics")
            {
                string followedOrJoined = command.Split()[1];

                if (followedOrJoined == "joined")
                {
                    string vloggerName = command.Split()[0];

                    if (!app.ContainsKey(vloggerName))
                    {
                        app.Add(vloggerName, new Dictionary<string, SortedSet<string>>());
                        app[vloggerName].Add("following", new SortedSet<string>());
                        app[vloggerName].Add("followers", new SortedSet<string>());
                    }
                }
                else if (followedOrJoined == "followed")
                {
                    string vloggerFollower = command.Split()[0];
                    string vloggerFollowed = command.Split()[2];

                    if (app.ContainsKey(vloggerFollower) &&
                        app.ContainsKey(vloggerFollowed) &&
                        vloggerFollower != vloggerFollowed)
                    {
                        app[vloggerFollower]["following"].Add(vloggerFollowed);
                        app[vloggerFollowed]["followers"].Add(vloggerFollower);
                    }
                }

                command = Console.ReadLine();
            }

            var sortedDataApp = app
                .OrderByDescending(kvp => kvp.Value["followers"].Count)
                .ThenBy(kvp => kvp.Value["following"].Count)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            Console.WriteLine($"The V-Logger has a total of {app.Count} vloggers in its logs.");

            int count = 1;
            foreach (var vlogger in sortedDataApp)
            {
                int followersCount = vlogger.Value["followers"].Count;
                int followingCount = vlogger.Value["following"].Count;

                Console.WriteLine($"{count}. {vlogger.Key} : {followersCount} followers, {followingCount} following");

                if (count == 1)
                {
                    foreach (string followers in vlogger.Value["followers"])
                    {
                        Console.WriteLine($"*  {followers}");
                    }
                }

                count += 1;
            }
        }
    }
}
