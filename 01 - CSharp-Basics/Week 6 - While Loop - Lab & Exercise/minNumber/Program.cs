using System;

namespace minNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int minNum = int.MaxValue;
            int counter = 0;

            while (counter < num)
            {
                int currNum = int.Parse(Console.ReadLine());
                if (currNum < minNum)
                {
                    minNum = currNum;
                }
                counter += 1;
            }
            Console.WriteLine(minNum);
        }
    }
}