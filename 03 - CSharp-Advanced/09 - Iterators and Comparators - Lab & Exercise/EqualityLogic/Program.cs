using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Person> sortedSetPerson = new SortedSet<Person>();
            HashSet<Person> hashSetPerson = new HashSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                Person p = new Person(input[0], int.Parse(input[1]));

                sortedSetPerson.Add(p);
                hashSetPerson.Add(p);
            }

            Console.WriteLine(sortedSetPerson.Count); 
            Console.WriteLine(hashSetPerson.Count);
        }
    }
}
