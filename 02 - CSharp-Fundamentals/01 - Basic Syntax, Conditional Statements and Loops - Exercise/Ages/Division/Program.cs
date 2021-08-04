using System;

namespace Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = int.Parse(Console.ReadLine());

            if (value % 2 == 0 && value % 10 == 0)
            {
                Console.WriteLine("The number is divisible by 10");
            }
            else if (value % 7 == 0)
            {
                Console.WriteLine("The number is divisible by 7");
            }
            else if(value % 2 == 0 && value % 3 == 0)
            {
                Console.WriteLine("The number is divisible by 6");
            }
            else if (value % 3 == 0)
            {
                Console.WriteLine("The number is divisible by 3");
            }
            else if (value % 2 == 0)
            {
                Console.WriteLine("The number is divisible by 2");
            }
            else
            {
                Console.WriteLine("Not divisible");
            }
        }
    }
}
