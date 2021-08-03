using System;

namespace bonusPts
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            double bonusPts = 0.0;

            if (num <= 100)
            {
                bonusPts = 5;
            }
            else if (num > 1000)
            {
                bonusPts = num * 0.1;
            }
            else
            {
                bonusPts = num * 0.2;
            }
            

            if (num % 2 == 0)
            {
                bonusPts = bonusPts + 1;
            }
            else if (num % 10 == 5)
            {
                bonusPts += 2;
            }

            Console.WriteLine(bonusPts);
            Console.WriteLine(num + bonusPts);
        }
    }
}
