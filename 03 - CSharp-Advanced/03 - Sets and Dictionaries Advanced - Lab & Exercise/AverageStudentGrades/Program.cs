using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    // dictionaries

    class Program
    {
        //7
        //Ivancho 5.20
        //Mariika 5.50
        //Ivancho 3.20
        //Mariika 2.50
        //Stamat 2.00
        //Mariika 3.46
        //Stamat 3.00

        //Ivancho -> 5,20 3,20 (avg: 4,20)
        //Mariika -> 5,50 2,50 3,46 (avg: 3,82)
        //Stamat -> 2,00 3,00 (avg: 2,50)

        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> studentsGrades 
                = new Dictionary<string, List<decimal>>();

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

            Console.WriteLine();
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
