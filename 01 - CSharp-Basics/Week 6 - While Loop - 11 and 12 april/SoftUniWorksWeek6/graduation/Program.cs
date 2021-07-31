using System;

namespace graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double totalGrades = 0;
            int classCount = 0;

            while (classCount < 12)
            {
                double grade = double.Parse(Console.ReadLine());

                if (grade >= 4.00)
                {
                    classCount++;
                    totalGrades += grade;
                }
            }
            double averageGrade = totalGrades / classCount;
            Console.WriteLine($"{name} graduated. Average grade: {averageGrade:f2}");
        }
    }
}
