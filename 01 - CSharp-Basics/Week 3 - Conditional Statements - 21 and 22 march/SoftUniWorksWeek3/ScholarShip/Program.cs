using System;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double grade = double.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());
            double socialScholarship = 0;
            double gradeScholarship = 0;
            if (income < salary)
            {
                if (grade > 4.5)
                {
                    socialScholarship = salary * 0.35;
                }
            }
            
            if (grade >= 5.5)
            {
                gradeScholarship = grade * 25;
            }
            if (gradeScholarship == 0)
            {
                if (socialScholarship == 0)
                {
                    Console.WriteLine("You cannot get a scholarship!");
                }
                else
                {
                    Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
                }
            }
            else if(socialScholarship == 0)
            {
                if (gradeScholarship == 0)
                {
                    Console.WriteLine($"You cannot get a scholarship!");
                }
                else
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(gradeScholarship)} BGN");
                }
            }
            else
            {
                if (socialScholarship > gradeScholarship)
                {
                    Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
                }
                else
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(gradeScholarship)} BGN");
                }
            }
        }
    }
}
