using System;

namespace Exercise_KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputTwo = Console.ReadLine().Split();
            Action<string[]> print = Print;
            print(inputTwo);
        }

        static void Print(string[] inputTwo)
        {
            foreach (var word in inputTwo)
            {
                Console.WriteLine("Sir " + word);
            }
        }
    }
}
