using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(integers);

            int numbersToBePoped = input[1];
            int elementToLookFor = input[2];

            for (int j = 0; j < numbersToBePoped; j++)
            {
                stack.Pop();
            }

            if (stack.Contains(elementToLookFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count > 0)
                {
                    Console.WriteLine(stack.Min());
                }
                else
                {
                    Console.WriteLine(stack.Count);
                }
            }
        }
    }
}
