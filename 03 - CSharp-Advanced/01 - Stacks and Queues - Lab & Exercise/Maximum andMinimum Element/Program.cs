using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{

    class Program
    {
        static void Main(string[] args)
        {
            //10
            //2
            //1 47
            //1 66
            //1 32
            //4
            //3
            //1 25
            //1 16
            //1 8
            //4

            Stack<int> stack = new Stack<int>(); 

            int n = int.Parse(Console.ReadLine());

            List<int> toBePrinted = new List<int>();

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
