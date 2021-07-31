using System;
using System.Collections.Generic;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            // SoftUni rocks
            // Did you know Math.Round rounds to the nearest even integer?
            //string input1 = "SoftUni rocks";
            //string input2 = "Did you know Math.Round rounds to the nearest even integer?";

            string input1 = Console.ReadLine();

            SortedDictionary<char, int> lettersCounts = new SortedDictionary<char, int>();

            foreach (var letter in input1)
            {
                if (lettersCounts.ContainsKey(letter))
                {
                    lettersCounts[letter] += 1;
                }
                else
                {
                    lettersCounts.Add(letter, 1);
                }
            }

            foreach (var letter in lettersCounts)
            {
                Console.WriteLine($"{letter.Key}: {letter.Value} time/s");
            }
        }
    }
}
