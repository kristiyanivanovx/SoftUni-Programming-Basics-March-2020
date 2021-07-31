using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // queues
            // input
            // 1 2 3 4 5 6

            // output 
            // 2, 4, 6

            // input
            // 11 13 18 95 2 112 81 46

            // output
            // 18, 2, 112, 46

            string[] input = Console.ReadLine().Split().ToArray();
            Queue<string> queue = new Queue<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (int.Parse(input[i]) % 2 == 0)
                {
                    queue.Enqueue(input[i]);
                }
            }

            string result = String.Join(", ", queue);
            Console.WriteLine(result);
        }
    }
}
