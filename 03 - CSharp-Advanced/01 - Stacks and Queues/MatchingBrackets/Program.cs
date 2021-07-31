using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            // stacks

            // input
            // 1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5

            // output
            // (2 + 3)
            // (3 + 1)
            // (2 - (2 + 3) * 4 / (3 + 1))

            string expression = Console.ReadLine();
            Stack<int> bracketsIndexes = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    bracketsIndexes.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int startIndex = bracketsIndexes.Pop();
                    Console.WriteLine(expression.Substring(startIndex, i - startIndex + 1));
                }
            }
        }
    }
}
