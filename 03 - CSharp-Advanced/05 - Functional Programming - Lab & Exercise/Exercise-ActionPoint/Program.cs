using System;

namespace Exercise_ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = "Lucas Noah Tea".Split();

            Action<string[]> printInput = Print;
            Print(input);

            void Print(string[] input)
            {
                Console.WriteLine(string.Join(Environment.NewLine, input));
            }

            Console.WriteLine(Environment.NewLine + "-------------------------" + Environment.NewLine);

            string[] inputTwo = "Eathan Lucas Noah StanleyRoyce".Split();

            Action<string[]> printInputTwo = PrintTwo;
            PrintTwo(inputTwo);

            void PrintTwo(string[] inputTwo)
            {
                foreach (var word in inputTwo)
                {
                    Console.WriteLine("Sir " + word);
                }
            }
        }
    }
}
