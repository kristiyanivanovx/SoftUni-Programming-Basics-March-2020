using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class Program
    {
        //4 3
        //1
        //3
        //5
        //7
        //3
        //4
        //5

        // 3 5

        //2 2
        //1
        //3
        //1
        //5

        //1
        static void Main(string[] args)
        {
            int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
            HashSet<int> hashsetN = new HashSet<int>();
            HashSet<int> hashsetM = new HashSet<int>();

            int n = nm[0];
            int m = nm[1];

            for (int i = 0; i < n; i++)
            {
                int inputN = int.Parse(Console.ReadLine());
                hashsetN.Add(inputN);
            }

            for (int j = 0; j < m; j++)
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
