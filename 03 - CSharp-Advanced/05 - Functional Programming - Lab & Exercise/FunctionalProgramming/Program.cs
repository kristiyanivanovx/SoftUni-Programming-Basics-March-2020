using System;
using System.Collections.Generic;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            // anonymous functions have no name
            // delegates are data types that point to a method and are used to pass methods as arguments to other methods
            // generic delegate - Func<T, V>

            // Func <T, V>
            // all but the last in <> are the arguments we take
            // last/right value is the type we return
            // right from the = is the method that we point to (can be lambda)

            // Action<T> - only in, no output --> void

            Func<int, string> agePrinter = GetAge;
            Console.WriteLine(agePrinter(5));

            Func<int, string> agePrinterLambda = (age) => $"Your lambda! age is: {age}";
            Console.WriteLine(agePrinterLambda(6));
        }

        static string GetAge(int age)
        {
            return $"Your age is: {age}";
        }

        static void Print(List<string> allNames)
        {
            Console.WriteLine(string.Join(Environment.NewLine, allNames));
        }

        static List<int> CustomWhere(List<int> numbers, Predicate<int> predicate)
        {
            List<int> newNumbers = new List<int>();

            foreach (var currNum in numbers)
            {
                if (predicate(currNum))
                {
                    newNumbers.Add(currNum);
                }
            }

            return newNumbers;
        }
    }
}
