using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            HashSet<int> hashsetN = new HashSet<int>();
            HashSet<int> hashsetM = new HashSet<int>();

            int valueN = input[0];
            int valueM = input[1];

            for (int i = 0; i < valueN; i++)
            {
                int inputN = int.Parse(Console.ReadLine());
                hashsetN.Add(inputN);
            }

            for (int j = 0; j < valueM; j++)
            {
                int inputM = int.Parse(Console.ReadLine());
                hashsetM.Add(inputM);
            }

            HashSet<int> answer = new HashSet<int>(hashsetN);
            answer.IntersectWith(hashsetM);

            Console.WriteLine(string.Join(" ", answer));
        }
    }
}
