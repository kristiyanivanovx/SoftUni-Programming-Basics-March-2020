using System;

namespace simpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            string operatorSign = Console.ReadLine();
            double result = 0;
            bool zeroDivision = false;

            if (num2 == 0)
            {
                zeroDivision = true;
            }

            switch (operatorSign)
            {
                case "+":
                    result = num1 + num2;
                    break;

                case "-":
                    result = num1 - num2;
                    break;

                case "*":
                    result = num1 * num2;
                    break;

                case "/":
                    if (zeroDivision)
                    {

                    }
                    else
                    {
                        result = 1.0 * num1 / num2;
                    }
                    break;

                case "%":
                    if (zeroDivision)
                    {

                    }
                    else
                    {
                        result = num1 % num2;
                    }
                    break;

            }
            string evenOrOdd = "";
            if (result % 2 == 0)
            {
                evenOrOdd = "even";
            }
            else
            {
                evenOrOdd = "odd";
            }

            if (operatorSign == "+" || operatorSign == "-" || operatorSign == "*")
            {
                Console.WriteLine($"{num1} {operatorSign} {num2} = {result} - {evenOrOdd}");
            }
            else if (zeroDivision)
            {
                Console.WriteLine($"Cannot divide {num1} by zero");
            }
            else if (operatorSign == "%")
            {
                Console.WriteLine($"{num1} % {num2} = {result}");
            }
            else if (result == 0)
            {
                Console.WriteLine($"{num1} {operatorSign} {num2} = 0.00");
            }
            else
            {
                Console.WriteLine($"{num1} {operatorSign} {num2} = {result:f2}");
            }
        }
    }
}