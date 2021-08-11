using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> predicate = (number) => true;

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();

            int start = numbers[0];
            int end = numbers[1];

            IEnumerable<int> numbersRange = Enumerable.Range(start, (end - start + 1));

            if (command == "odd")
            {
                predicate = (number) => number % 2 != 0;
            }
            else if (command == "even")
            {
                predicate = (number) => number % 2 == 0;
            }

            foreach (int number in numbersRange)
            {
                if (predicate(number))
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}
