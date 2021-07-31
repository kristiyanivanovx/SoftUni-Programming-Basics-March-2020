using System;
using System.Collections.Generic;
using System.Linq;

namespace StacksAndQueues
{
    class Program
    {
        static void Main(string[] args)
        {
            // stacks

            // 1. reverse strings
            // I Love C#
            // Stacks and Queues

            string input = Console.ReadLine();
            Stack<char> reversedStack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                reversedStack.Push(input[i]);
            }

            while (reversedStack.Count > 0)
            {
                Console.Write(reversedStack.Pop());
            }
        }
    }
}
