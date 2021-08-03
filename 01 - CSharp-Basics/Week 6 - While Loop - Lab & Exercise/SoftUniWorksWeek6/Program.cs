using System;

namespace SoftUniWorksWeek6
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 5;
            while (true)
            {
                if (num > 10)
                {
                    break;
                }
                Console.WriteLine($"num = {num}");
                num++;
            }
        }
    }
}
