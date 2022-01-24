using System;
using System.Collections.Generic;

namespace CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> sequence = FinSequence();
            Console.WriteLine(string.Join(" ", sequence));
        }

        private static List<char> FinSequence()
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());

            int start = Math.Min(first, second);
            int end = Math.Max(first, second);

            List<char> sequence = new List<char>();

            for (int i = start + 1; i < end; i++)
            {
                char current = (char)i;
                sequence.Add(current);
            }

            return sequence;
        }
    }
}
