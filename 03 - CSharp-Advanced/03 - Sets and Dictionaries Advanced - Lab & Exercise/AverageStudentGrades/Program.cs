using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> studentsGrades = new Dictionary<string, List<decimal>>();
            int inputSize = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputSize; i++)
            {
                string[] studentWithMark = Console.ReadLine().Split();
                var studentName = studentWithMark[0];
                decimal studentGrade = decimal.Parse(studentWithMark[1], System.Globalization.CultureInfo.InvariantCulture);

                if (!studentsGrades.ContainsKey(studentName))
                {
                    studentsGrades.Add(studentName, new List<decimal>());
                }

                studentsGrades[studentName].Add(studentGrade);
            }

            foreach (var student in studentsGrades)
            {
                Console.Write($"{student.Key} -> ");
                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }

                Console.WriteLine($"(avg: {student.Value.Average():f2})");
            }
        }
    }
}
