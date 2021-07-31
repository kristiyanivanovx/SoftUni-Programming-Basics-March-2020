using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise_PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            //4
            //Kurnelia Qnaki Geo Muk Ivan

            //Geo
            //Muk
            //Ivan

            //4
            //Karaman Asen Kiril Yordan

            //Asen

            int length = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split().ToList();

            Predicate<string> predicate = (name) => name.Length <= 4;

            foreach (string name in names)
            {
                if (predicate(name))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
