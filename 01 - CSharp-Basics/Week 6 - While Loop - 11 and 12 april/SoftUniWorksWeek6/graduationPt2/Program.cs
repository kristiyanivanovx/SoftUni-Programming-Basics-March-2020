using System;

namespace graduationPt2
{
    class Program
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();
            int gradesCount = 1;
            double gradesSum = 0;

            while (gradesCount <= 12)
            {
                double mark = double.Parse(Console.ReadLine());

                if (mark >= 4)
                {
                    gradesSum += mark;
                    gradesCount++;
                }

                if (mark < 4)
                {
                    gradesSum += mark;
                    Console.WriteLine($"{studentName} has been excluded at {gradesCount} grade");
                    return;
                }
            }
            Console.WriteLine($"{studentName} graduated. Average grade: {gradesSum / 12:f2} ");
        }
    }
}