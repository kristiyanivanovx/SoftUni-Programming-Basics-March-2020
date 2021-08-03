using System;

namespace ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] data = input.Split(new char[] { '\\', '.' });

            Console.WriteLine("File name: " + data[data.Length - 2]);
            Console.WriteLine("File extension: " + data[data.Length - 1]);
        }
    }
}
