using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> academy = new Dictionary<string, List<double>>();
            int value = int.Parse(Console.ReadLine());

            for (int i = 0; i < value; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (academy.ContainsKey(name))
                {
                    academy[name].Add(grade);
                }
                else
                {
                    var grades = new List<double>() { grade };
                    academy.Add(name, grades);
                }
            }

            academy = academy
                .ToList()
                .Where(x => x.Value.Average() >= 4.50d)
                .OrderByDescending(x => x.Value.Average())
                .ToDictionary(x => x.Key, x => x.Value);

            academy.ToList().ForEach(x => Console.WriteLine($"{x.Key} -> {x.Value.Average():f2}"));
        }
    }
}
