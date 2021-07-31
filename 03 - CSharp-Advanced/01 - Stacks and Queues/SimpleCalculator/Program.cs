using System;
using System.Collections.Generic;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // stacks
            
            //Input                 Output
            //2 + 5 + 10 - 2 - 1    14
            //2 - 2 + 5             5

            string[] expression = Console.ReadLine().Split();
            Stack<string> calculatorStack = new Stack<string>(new Stack<string>(expression));

            while (calculatorStack.Count > 1)
            {
                int first = int.Parse(calculatorStack.Pop());
                string operatorSign = calculatorStack.Pop();
                int second = int.Parse(calculatorStack.Pop());

                if (operatorSign == "+")
                {
                    calculatorStack.Push((first + second).ToString());
                }
                else if (operatorSign == "-")
                {
                    calculatorStack.Push((first - second).ToString());
                }
            }

            Console.WriteLine(calculatorStack.Pop());
        }
    }
}
