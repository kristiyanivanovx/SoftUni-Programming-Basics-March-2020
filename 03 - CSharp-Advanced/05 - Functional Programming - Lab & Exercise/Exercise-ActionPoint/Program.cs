using System;

namespace Exercise_ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Action<string[]> printInput = Print;
            printInput(input);
        }
        static void Print(string[] input)
        {
            Console.WriteLine(string.Join(Environment.NewLine, input));
        }
    }
}
