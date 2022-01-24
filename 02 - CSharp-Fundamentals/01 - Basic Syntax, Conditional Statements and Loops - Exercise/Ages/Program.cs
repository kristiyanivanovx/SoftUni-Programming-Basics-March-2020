using System;

namespace Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = int.Parse(Console.ReadLine());

            if (0 <= value && value <= 2)
            {
                Console.WriteLine("baby");
            }
            else if (3 <= value && value <= 13)
            {
                Console.WriteLine("child");
            }
            else if (14 <= value && value <= 19)
            {
                Console.WriteLine("teenager");
            }
            else if (20 <= value && value <= 65)
            {
                Console.WriteLine("adult");
            }
            else if (value >= 66)
            {
                Console.WriteLine("elder");
            }
        }
    }
}
