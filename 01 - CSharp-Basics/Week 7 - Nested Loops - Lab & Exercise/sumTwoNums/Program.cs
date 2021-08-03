using System;

namespace sumTwoNums
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());
            bool isFound = false;
            int count = 0;
            int x = 0;
            int y = 0;

            if (start > end)
            {
                int temp = start;
                start = end;
                end = temp;
            }

            for (int num1 = start; num1 <= end; num1++)
            {
                for (int num2 = start; num2 <= end; num2++)
                {
                    count++;
                    if (num1 + num2 == magicNum)
                    {
                        x = num1;
                        y = num2;
                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                {
                    break;
                }
            }

            if (isFound)
            {
                Console.WriteLine($"Combination N:{count} ({x} + {y} = {magicNum})");
            }
            else
            {
                Console.WriteLine($"{count} combinations - neither equals {magicNum}");
            }
        }
    }
}
