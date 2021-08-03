using System;

namespace maxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int maxNum = int.MinValue;
            int counter = 0;

            while (counter < num)
            {
                int currNum = int.Parse(Console.ReadLine());
                if (currNum > maxNum)
                {
                    maxNum = currNum;
                }
                counter += 1;
            }
            Console.WriteLine(maxNum);
        }
    }
}