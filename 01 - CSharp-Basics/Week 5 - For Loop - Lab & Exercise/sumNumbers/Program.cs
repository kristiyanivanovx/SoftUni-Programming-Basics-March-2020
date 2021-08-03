using System;

namespace sumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < count; i++)
            {
                int currNum = int.Parse(Console.ReadLine());
                sum += currNum;
            }
            Console.WriteLine(sum);
        }
    }
}
