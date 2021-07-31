using System;

namespace divideWithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int firstGroup = 0;
            int secondGroup = 0;
            int thirdGroup = 0;
            double p1 = 0.0;
            double p2 = 0.0;
            double p3 = 0.0;

            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                
                if (num % 2 == 0)
                {
                    firstGroup++;
                }

                if (num % 3 == 0)
                {
                    secondGroup++;
                }

                if (num % 4 == 0)
                {
                    thirdGroup++;
                }
            }

            p1 = (firstGroup * 1.0 / n) * 100.0;
            p2 = (secondGroup * 1.0 / n) * 100.0;
            p3 = (thirdGroup * 1.0 / n) * 100.0;

            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
        }
    }
}
