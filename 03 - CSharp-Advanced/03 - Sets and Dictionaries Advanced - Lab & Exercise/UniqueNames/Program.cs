using System;
using System.Collections.Generic;

namespace UniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            HashSet<string> uniqueNames = new HashSet<string>();

            for (int i = 0; i < number; i++)
            {
                string name = Console.ReadLine();
                uniqueNames.Add(name);
            }

            foreach (var item in uniqueNames)
            {
                Console.WriteLine(item);
            }
        }
    }
}
