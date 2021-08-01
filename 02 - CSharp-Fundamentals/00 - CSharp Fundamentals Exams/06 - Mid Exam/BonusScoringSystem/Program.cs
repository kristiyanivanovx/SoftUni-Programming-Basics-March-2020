using System;
using System.Collections.Generic;
using System.Linq;

namespace BonusScoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> scores = new Dictionary<int, int>();

            int studentsCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());

            if (studentsCount == 0 || lecturesCount == 0)
            {
                Console.WriteLine($"Max Bonus: 0.");
                Console.WriteLine($"The student has attended 0 lectures.");
                return;
            }

            string input = Console.ReadLine();
            for (int i = 0; i < studentsCount; i++)
            {
                int studentAttendances = int.Parse(input);
                double totalBonus = studentAttendances * 1.0 / lecturesCount * (5.0 + additionalBonus) * 1.0;
                double value = Math.Round(totalBonus);

                if (!scores.ContainsKey((int)value))
                {
                    scores.Add((int)value, studentAttendances);
                }

                input = Console.ReadLine();
            }

            scores = scores.OrderByDescending(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine($"Max Bonus: {scores.First().Key}.");
            Console.WriteLine($"The student has attended {scores.First().Value} lectures.");
        }
    }
}
