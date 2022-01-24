using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise_PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Predicate<string> predicate = (name) => name.Length <= length;
            
            List<string> names = Console.ReadLine()
                .Split()
                .Where(x => predicate(x))
                .ToList();

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
