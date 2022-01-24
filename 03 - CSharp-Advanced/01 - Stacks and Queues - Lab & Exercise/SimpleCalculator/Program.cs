using System;
using System.Collections.Generic;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> calculator = new Stack<string>(new Stack<string>(input));

            while (calculator.Count > 1)
            {
                int firstDigit = int.Parse(calculator.Pop());
                string operatorSign = calculator.Pop();
                int secondDigit = int.Parse(calculator.Pop());

                if (operatorSign == "+")
                {
                    calculator.Push((firstDigit + secondDigit).ToString());
                }
                else if (operatorSign == "-")
                {
                    calculator.Push((firstDigit - secondDigit).ToString());
                }
            }

            Console.WriteLine(calculator.Pop());
        }
    }
}
