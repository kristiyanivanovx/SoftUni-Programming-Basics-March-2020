using System;

namespace sumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumPrimes = 0;
            int sumNonPrimes = 0;
            string input = Console.ReadLine();

            while (input != "stop")
            {
                int num = int.Parse(input);

                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                else if (num <= 1)
                {
                    sumNonPrimes += num;
                }
                else if (num == 2)
                {
                    sumPrimes += num;
                }
                else
                {
                    bool isPrime = true;
                    for (int i = 3; i <= num / 2; i++)
                    {
                        if (num % i == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }

                    if (isPrime)
                    {
                        sumPrimes += num;
                    }
                    else
                    {
                        sumNonPrimes += num;
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {sumPrimes}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrimes}");
        }
    }
}
