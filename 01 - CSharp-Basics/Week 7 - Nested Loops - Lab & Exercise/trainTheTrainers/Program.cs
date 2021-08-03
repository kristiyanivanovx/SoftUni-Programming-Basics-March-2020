using System;

namespace trainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int jury = int.Parse(Console.ReadLine());
            string title = Console.ReadLine();
            double totalMarks = 0;
            int presentationCount = 0;

            while (title != "Finish")
            {
                double currentMarks = 0;
                for (int i = 0; i < jury; i++)
                {
                    currentMarks += double.Parse(Console.ReadLine());
                }
                Console.WriteLine($"{title} - {currentMarks / jury:f2}.");
                totalMarks += currentMarks;
                presentationCount++;
                title = Console.ReadLine();
            }
            Console.WriteLine($"Student's final assessment is {totalMarks / presentationCount / jury:f2}.");
        }
    }
}
