using System;

namespace leftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < count; i++)
            {
                int leftNum = int.Parse(Console.ReadLine());
                leftSum += leftNum;
            }

            for (int i = 0; i < count; i++)
            {
                int rightNum = int.Parse(Console.ReadLine());
                rightSum += rightNum;
            }

            if (rightSum == leftSum)
            {
                Console.WriteLine($"Yes, sum = {rightSum}");
            }
            else
            {
                int diff = 0;
                if (rightSum < leftSum)
                {
                    diff = leftSum - rightSum;
                }
                else
                {
                    diff = rightSum - leftSum;
                }
                Console.WriteLine($"No, diff = {diff}");
            }
        }
    }
}
