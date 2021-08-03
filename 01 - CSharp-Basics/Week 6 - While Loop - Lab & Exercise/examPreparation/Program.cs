using System;

namespace examPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int poorMarksLimit = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            bool needsBreak = false;
            string taskName = "";
            double totalMarks = 0;
            int poorMarksCount = 0;
            int tasksSolved = 0;

            while (input != "Enough")
            {

                taskName = input;
                int mark = int.Parse(Console.ReadLine());
                tasksSolved++;
                totalMarks += mark;

                if (mark <= 4)
                {
                    poorMarksCount++;
                    if (poorMarksCount >= poorMarksLimit)
                    {
                        needsBreak = true;
                        break;
                    }
                }

                input = Console.ReadLine();
            }

            if (needsBreak)
            {
                Console.WriteLine($"You need a break, {poorMarksLimit} poor grades.");
            }
            else
            {
                double averageScore = 1.0 * totalMarks / tasksSolved;
                Console.WriteLine($"Average score: {averageScore:f2}");
                Console.WriteLine($"Number of problems: {tasksSolved}");
                Console.WriteLine($"Last problem: {taskName}");
            }
        }
    }
}