using System;

namespace halfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int maxNum = int.MinValue;

            for (int i = 1; i <= n; i++)
            {
                // read num
                int num = int.Parse(Console.ReadLine());
                // add it to sum
                sum += num;
                // check if its maxNum
                if (maxNum < num)
                {
                    maxNum = num;
                }
            }

            int sumWithoutMax = sum - maxNum;
            if (sumWithoutMax == maxNum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sumWithoutMax}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(sumWithoutMax - maxNum)}");
            }
        }
    }
}
