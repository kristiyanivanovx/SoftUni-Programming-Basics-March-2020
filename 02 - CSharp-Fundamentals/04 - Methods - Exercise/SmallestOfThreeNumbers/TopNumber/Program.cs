using System;
using System.Linq;

namespace TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = int.Parse(Console.ReadLine());
            FindTopNumbers(value);
        }

        static void FindTopNumbers(int value)
        {
            for (int i = 1; i <= value; i++)
            {
                int sumOfDigits = i.ToString().ToCharArray().Sum(x => int.Parse(x.ToString()));
                bool hasOddNumber = i.ToString().ToCharArray().Any(x => int.Parse(x.ToString()) % 2 != 0);
                bool isTopNumber = sumOfDigits % 8 == 0 && hasOddNumber;

                if (isTopNumber)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
