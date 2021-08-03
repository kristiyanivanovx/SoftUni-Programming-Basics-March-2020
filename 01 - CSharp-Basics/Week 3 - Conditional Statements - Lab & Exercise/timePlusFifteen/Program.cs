using System;

namespace timePlusFifteen
{
    class Program
    {
        static void Main(string[] args)
        {
            // read h
            // read m

            int h = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            // add 15 min to min
            
            m += 15;
            if (m >= 60)
            {
                m = m - 60;
                h += 1;
            }
            // check if min >= 60
            if (h >= 24)
            {
                h = 0;
            }
            Console.WriteLine($"{h}:{m:d2}");
        }
    }
}
