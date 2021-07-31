using System;
using System.Collections.Generic;
using System.Linq;

namespace Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 2 3 4 5 6 
            //2 4 6 1 3 5

            //-3 2
            //2 -3 
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Array.Sort(numbers, (a, b) =>
            {
                // a - odd and b - even
                if (a % 2 != 0 && b % 2 == 0)
                {
                    return 1;
                }

                // a - even and b - odd
                if (a % 2 == 0 && b % 2 != 0)
                {
                    return -1;
                }

                int temp = a.CompareTo(b);
                return temp;
            });

            Console.WriteLine(string.Join(" ", numbers));
        }

        static void Print(List<string> allNames)
        {
            Console.WriteLine(string.Join(Environment.NewLine, allNames));
        }

        static List<int> CustomWhere(List<int> numbers, Predicate<int> predicate)
        {
            List<int> newNumbers = new List<int>();

            foreach (var currNum in numbers)
            {
                if (predicate(currNum))
                {
                    newNumbers.Add(currNum);
                }
            }

            return newNumbers;
        }
    }
}
