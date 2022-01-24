using System;
using System.Linq;
using System.Collections.Generic;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Task();
            //TestStack();
        }

        public static void Task()
        {
            string input = Console.ReadLine();
            CustomStack<string> customStack = new CustomStack<string>();

            while (input != "END")
            {
                if (input.Contains("Push"))
                {
                    IEnumerable<string> elements = input
                        .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Skip(1);

                    customStack.Push(elements);
                }
                else if (input == "Pop")
                {
                    customStack.Pop();
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (string item in customStack)
                {
                    if (item != null)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }

        public static void TestStack()
        {
            CustomStack<string> customStack = new CustomStack<string>();

            customStack.Push(new string[] { "10" });
            customStack.Push(new string[] { "20" });
            customStack.Push(new string[] { "30" });

            Console.WriteLine(customStack.Pop());
            Console.WriteLine(customStack.Pop());
            Console.WriteLine(customStack.Pop());
            Console.WriteLine(customStack.Pop());
        }
    }
}
