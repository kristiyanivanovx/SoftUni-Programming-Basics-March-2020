using System;
using System.Collections.Generic;

namespace VLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            // vlogger name, vlogger's followers
            Dictionary<string, Dictionary<string, int>> vloggers =
                new Dictionary<string, Dictionary<string, int>>();

            while (!command.Contains("Statistics"))
            {
                if (command.Contains("joinеd The V-Logger"))
                {
                    // "{vloggername}" joined The V-Logge
                    string vloggerName = command.Split()[0];
                    if (!vloggers.ContainsKey(vloggerName))
                    {
                        vloggers.Add(vloggerName, new Dictionary<string, int>());
                    }
                }

                if (command.Contains("followed"))
                {
                    // "{vloggername} followed {vloggername}"
                    string vloggerFollower = command.Split()[0];
                    string vloggerFollowed = command.Split()[2];

                    if (vloggers.ContainsKey(vloggerFollowed) &&
                        vloggers.ContainsKey(vloggerFollower)) 
                    {
                        if (!vloggers[vloggerFollower].ContainsKey(vloggerFollowed) &&
                            vloggerFollower != vloggerFollowed)
                        {
                            int followedCount = vloggers[vloggerFollower].Count;
                            int followersCount = vloggers[vloggerFollowed].Count;

                            vloggers[vloggerFollower].Add(vloggerFollowed, ++followedCount);
                            vloggers[vloggerFollowed].Add(vloggerFollower, ++followersCount);
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"The V - Logger has a total of {vloggers.Count} vloggers in its logs.");

            int count = 1;
            foreach (var vlogger in vloggers)
            {
                Console.WriteLine($"{count}. {vlogger.Key} : {vlogger.Value.Count}");

                foreach (var followers in vlogger.Value)
                {
                    Console.WriteLine($"*  {followers.Key}");
                }

                count++;
            }
        }
    }
}
