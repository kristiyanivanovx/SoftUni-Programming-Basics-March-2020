using System;

namespace MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal first = decimal.Parse(Console.ReadLine());
            decimal second = decimal.Parse(Console.ReadLine());
            Console.WriteLine(first * second);
        }
    }
}
