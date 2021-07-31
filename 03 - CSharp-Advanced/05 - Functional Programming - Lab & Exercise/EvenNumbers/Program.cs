using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //// 3, 5, 7, 9, 1, 2, 4, 6, 8, 10
            //int[] evenNumbers = "3, 5, 7, 9, 1, 2, 4, 6, 8, 10".Split(", ")
            //                                                   .Select(int.Parse)
            //                                                   .ToArray()
            //                                                   .Where(x => x % 2 == 0)
            //                                                   .ToArray();

            //Console.WriteLine(string.Join(", ", evenNumbers));

            ////int [] evenNumbers = numbers.Where(x => x % 2 == 0).ToArray();

            //Console.WriteLine("----------------------------------");

            //1 10
            //odd

            //1 3 5 7 9

            //20 30
            //even

            //20 22 24 26 28 30

            Predicate<int> predicate = (number) => true;

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();

            int start = numbers[0];
            int end = numbers[1];

            IEnumerable<int> numbersRange = Enumerable.Range(start, (end-start + 1));

            // even // odd

            if (command == "odd")
            {
                predicate = (number) => number % 2 != 0;
            }
            else if (command == "even")
            {
                predicate = (number) => number % 2 == 0;
            }

            foreach (var numb in numbersRange)
            {
                if (predicate(numb))
                {
                    Console.Write(numb + " ");
                }
            }
        }
    }
}
