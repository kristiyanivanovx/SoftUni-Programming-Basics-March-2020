using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            // exercise 1
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = input[0];
            int s = input[1];
            int x = input[2];

            int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(integers);

            //for (int i = 0; i < n; i++)
            //{
            //    stack.Push(integers[i]);
            //}

            for (int j = 0; j < s; j++)
            {
                stack.Pop();
            }

            if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count > 0)
                {
                    Console.WriteLine(stack.Min());
                }
            }
        }
    }
}
