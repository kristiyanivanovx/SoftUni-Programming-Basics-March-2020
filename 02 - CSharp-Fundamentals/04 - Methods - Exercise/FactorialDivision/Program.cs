using System;

namespace FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            double first = double.Parse(Console.ReadLine());
            double second = double.Parse(Console.ReadLine());

            double result = (FindFactorial(first) / FindFactorial(second));

            Console.WriteLine($"{result:f2}");
        }

        static double FindFactorial(double number)
        {
            if (number == 0)
            {
                return 1;
            }

            return number * FindFactorial(number - 1);
        }
    }
}
