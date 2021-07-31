using System;

namespace histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int firstGroup = 0;
            int secondGroup = 0;
            int thirdGroup = 0;
            int forthGroup = 0;
            int fifthGroup = 0;

            for (int num = 1; num <= n; num++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number < 200)
                {
                    firstGroup++;
                }
                else if (number >= 200 && number < 400)
                {
                    secondGroup++;
                }
                else if (number >= 400 && number < 600)
                {
                    thirdGroup++;
                }
                else if (number >= 600 && number < 800)
                {
                    forthGroup++;
                }
                else if (number >= 800)
                {
                    fifthGroup++;
                }
            }

            double p1 = firstGroup * 1.0 / n * 100;
            double p2 = secondGroup * 1.0 / n * 100;
            double p3 = thirdGroup * 1.0 / n * 100;
            double p4 = forthGroup * 1.0 / n * 100;
            double p5 = fifthGroup * 1.0 / n * 100;

            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
            Console.WriteLine($"{p4:f2}%");
            Console.WriteLine($"{p5:f2}%");
        }
    }
}
