using System;

namespace specialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int d1 = 1; d1 <= 9; d1++)
            {
                if (number % d1 != 0)
                {
                    continue;
                }
                for (int d2 = 1; d2 <= 9; d2++)
                {
                    if (number % d2 != 0)
                    {
                        continue;
                    }
                    for (int d3 = 1; d3 <= 9; d3++)
                    {
                        if (number % d3 != 0)
                        {
                            continue;
                        }
                        for (int d4 = 1; d4 <= 9; d4++)
                        {
                            if (number % d4 != 0)
                            {
                                continue;
                            }
                            Console.Write($"{d1}{d2}{d3}{d4} ");
                        }
                    }
                }
            }
        }
    }
}
