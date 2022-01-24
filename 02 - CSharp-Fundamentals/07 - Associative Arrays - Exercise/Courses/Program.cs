using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();
            while (!command.Contains("end"))
            {
                var data = command.Split(" : ");
                string courseName = data[0];
                string student = data[1];

                if (!courses.ContainsKey(courseName))
                {
                    var students = new List<string>() { student };
                    courses.Add(courseName, students);
                }
                else
                {
                    var course = courses.FirstOrDefault(x => x.Key == courseName);
                    course.Value.Add(student);
                }

                command = Console.ReadLine();
            }

            courses = courses.OrderByDescending(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Value);
            courses.ToList().ForEach(x =>
            {
                Console.WriteLine($"{x.Key}: {x.Value.Count}");
                x.Value.OrderBy(x => x).ToList().ForEach(s =>
                {
                    Console.WriteLine($"-- {s}");
                });
            });
        }
    }
}
