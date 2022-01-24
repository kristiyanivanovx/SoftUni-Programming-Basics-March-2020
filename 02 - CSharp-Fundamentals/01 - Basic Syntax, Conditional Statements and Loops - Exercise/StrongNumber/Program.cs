using System;
using System.Linq;

namespace StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            char[] values = input.ToString().ToCharArray();

            int sum = 0;

            values.ToList().ForEach(x =>
            {
                sum += Factorial(int.Parse(x.ToString()));
            });

            if (sum == input)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }

        static int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return Factorial(n - 1) * n;
        }
    }
}
