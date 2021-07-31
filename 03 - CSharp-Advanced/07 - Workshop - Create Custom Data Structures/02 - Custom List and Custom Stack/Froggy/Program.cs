using System;
using System.Collections.Generic;
using System.Linq;

namespace Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] input = "1, 2, 3, 4, 5, 6, 7, 8".Split(", ").Select(int.Parse).ToArray();
            //int[] input = "1, 2, 3, 4, 5".Split(", ").Select(int.Parse).ToArray();
            //int[] input = "13, 23, 1, -8, 4, 9".Split(", ").Select(int.Parse).ToArray();

            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Lake frogLake = new Lake(input);

            //frogLake.SortStones();
            //Console.WriteLine(string.Join(", ", frogLake.stonesSorted));

            List<int> lst = new List<int>();
            foreach (int item in frogLake)
            {
                lst.Add(item);
            }

            Console.WriteLine(string.Join(", ", lst));
        }
    }
}
