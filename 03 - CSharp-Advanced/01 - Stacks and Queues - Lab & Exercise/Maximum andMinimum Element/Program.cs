﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{

    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            List<int> toBePrinted = new List<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (input[0] == 1)
                {
                    stack.Push(input[1]);
                }
                else if (input[0] == 2)
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else if (input[0] == 3)
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Max());
                    }
                }
                else if (input[0] == 4)
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
