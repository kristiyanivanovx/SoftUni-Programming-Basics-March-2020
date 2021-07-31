using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            // contest name | contest
            Dictionary<string, string> availableContests =
                new Dictionary<string, string>();

            SortedDictionary<string, SortedDictionary<string, int>> students =
                new SortedDictionary<string, SortedDictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                //"{contest}:{password for contest}"
                string[] contestAndPassword = input.Split(":");
                string contest = contestAndPassword[0];
                string password = contestAndPassword[1];

                availableContests.Add(contest, password);
                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "end of submissions")
            {
                //"{contest}=>{password}=>{username}=>{points}
                string[] information = input.Split("=>");
                string contest = information[0];
                string password = information[1];
                string username = information[2];
                int points = int.Parse(information[3]);

                if (availableContests.ContainsKey(contest) && availableContests[contest] == password)
                {
                    if (!students.ContainsKey(username))
                    {
                        students.Add(username, new SortedDictionary<string, int>());
                    }

                    if (!students[username].ContainsKey(contest))
                    {
                        students[username].Add(contest, points);
                    }

                    if (students[username][contest] < points)
                    {
                        students[username][contest] = points;
                    }
                }

                input = Console.ReadLine();
            }

            var firstStudent = students.OrderByDescending(kvp => kvp.Value.Values.Sum()).First();

            Console.WriteLine($"Best candidate is {firstStudent.Key} with total {firstStudent.Value.Values.Sum()} points.");
            Console.WriteLine("Ranking:");

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key}");

                foreach (var course in student.Value.OrderByDescending(kvp => kvp.Value))
                {
                    Console.WriteLine($"#  {course.Key} -> {course.Value}");
                }
            }
        }
    }
}
