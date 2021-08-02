using System;

namespace AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            int result = Sum(first, second);
            result = Substract(result, third);

            Console.WriteLine(result);
        }

        static int Sum(int first, int second)
        {
            return first + second;
        }

        static int Substract(int original, int second)
        {
            return original - second;
        }
    }
}
