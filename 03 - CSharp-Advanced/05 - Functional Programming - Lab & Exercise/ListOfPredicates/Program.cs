using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            //100
            //2 5 10 20

            //20 40 60 80 100

            int end = int.Parse(Console.ReadLine());
            List<int> dividers = Console.ReadLine().Split().Select(int.Parse).ToList();
            
            //List<int> numbers = Enumerable.Range(1, end).ToList();

            Func<int, int, bool> predicate = (num, d) => num % d == 0;

            for (int num = 0; num <= end; num++)
            {
                if (dividers.All(d => predicate(num, d)) && num != 0)
                {
                    Console.Write(num + " ");
                }
            }

            //foreach (int num in numbers)
            //{
            //    if (dividers.All(d => predicate(num, d)))
            //    {
            //        Console.Write(num + " ");
            //    }
            //}

            //foreach (int num in numbers)
            //{
            //    if (dividers.All(d => num % d == 0))
            //    {
            //        Console.Write(num + " ");
            //    }
            //}
        }
    }
}
