using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());
            List<int> dividers = Console.ReadLine().Split().Select(int.Parse).ToList();
            Func<int, int, bool> predicate = (num, d) => num % d == 0;

            for (int num = 0; num <= end; num++)
            {
                if (dividers.All(d => predicate(num, d)) && num != 0)
                {
                    Console.Write(num + " ");
                }
            }
        }
    }
}
