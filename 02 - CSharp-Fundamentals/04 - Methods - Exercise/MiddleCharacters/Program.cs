using System;

namespace MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            FindMiddleCharacter(input);
        }

        private static void FindMiddleCharacter(string input)
        {
            int center = input.Length / 2;

            if (input.Length % 2 == 0)
            {
                Console.WriteLine(input[center - 1].ToString() + input[center].ToString());
            }
            else
            {
                Console.WriteLine(input[center].ToString());
            }
        }
    }
}
