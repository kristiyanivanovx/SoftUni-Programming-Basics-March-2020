using System;

namespace oddAndEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int oddSum = 0;
            int evenSum = 0;
            for (int i = 1; i <= count; i++)
            {
                int currNum = int.Parse(Console.ReadLine());
                
                if (i % 2 == 0)
                {
                    evenSum += currNum;
                }
                else
                {
                    oddSum += currNum;
                }
            }

            if (evenSum == oddSum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {evenSum}");
            }
            else
            {
                int diff = Math.Abs(oddSum - evenSum);
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {diff}");
            }
        }
    }
}
