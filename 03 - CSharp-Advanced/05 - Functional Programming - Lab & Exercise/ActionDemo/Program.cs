using System;

namespace ActionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printer = Print;
            printer("Alo");
        }

        public static void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
