using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
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
