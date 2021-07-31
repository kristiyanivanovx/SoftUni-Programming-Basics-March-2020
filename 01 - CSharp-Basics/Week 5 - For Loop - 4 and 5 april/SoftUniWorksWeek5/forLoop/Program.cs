using System;

namespace numbersEndingIn7
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 7; i <= 997; i += 10)
            {
                if (i % 10 == 7)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
