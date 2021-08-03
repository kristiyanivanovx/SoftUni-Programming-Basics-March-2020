using System;

namespace invalidNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            if ((number >= 100 || number == 0) && (number == 0 || 200 >= number))
            {

            }
            else
            {
                Console.WriteLine("invalid");
            }

        }
    }
}
