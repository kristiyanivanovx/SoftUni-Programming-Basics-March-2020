using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([A-Za-z]+)|([0-9]{1,})";
            List<string> participants = Console.ReadLine().Split(", ").ToList();
            Dictionary<string, int> dashboard = new Dictionary<string, int>();
            string command = Console.ReadLine();

            while (!command.Contains("end of race"))
            {
                string name = "";
                int kilometers = 0;

                MatchCollection matches = Regex.Matches(command, pattern);
                foreach (var match in matches)
                {
                    int value;
                    if (int.TryParse(match.ToString(), out value))
                    {
                        if (value >= 10)
                        {
                            string values = value.ToString();
                            for (int i = 0; i < values.Length; i++)
                            {
                                kilometers += int.Parse(values[i].ToString());
                            }
                        }
                        else
                        {
                            kilometers += value;
                        }
                    }
                    else
                    {
                        name += match.ToString();
                    }
                }

                if (participants.Contains(name))
                {
                    if (dashboard.ContainsKey(name))
                    {
                        dashboard[name] += kilometers;
                    }
                    else
                    {
                        dashboard.Add(name, kilometers);
                    }
                }

                command = Console.ReadLine();
            }

            dashboard = dashboard.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine($"1st place: {dashboard.ElementAt(0).Key}");
            Console.WriteLine($"2nd place: {dashboard.ElementAt(1).Key}");
            Console.WriteLine($"3rd place: {dashboard.ElementAt(2).Key}");
        }
    }
}
