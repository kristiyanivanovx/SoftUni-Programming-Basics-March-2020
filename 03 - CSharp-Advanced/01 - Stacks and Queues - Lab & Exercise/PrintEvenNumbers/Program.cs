using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();
            Queue<string> queue = new Queue<string>();

            for (int i = 0; i < input.Length; i++)
            {
                bool isEven = int.Parse(input[i]) % 2 == 0;
                if (isEven)
                {
                    queue.Enqueue(input[i]);
                }
            }

            string result = string.Join(", ", queue);
            Console.WriteLine(result);
        }
    }
}
