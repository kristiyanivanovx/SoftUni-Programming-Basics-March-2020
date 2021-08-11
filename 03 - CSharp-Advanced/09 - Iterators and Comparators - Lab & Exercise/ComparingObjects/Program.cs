using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            List<Person> persons = new List<Person>();
            int matchesCount = 0;

            while (input[0] != "END")
            {
                Person person = new Person(input[0], int.Parse(input[1]), input[2]);
                persons.Add(person);
                input = Console.ReadLine().Split();
            }

            int position = int.Parse(Console.ReadLine());

            for (int person = 0; person < persons.Count; person++)
            {
                if (persons[position - 1].CompareTo(persons[person]) == 0)
                {
                    matchesCount++;
                }
            }

            if (matchesCount == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                string str = $"{matchesCount} {persons.Count - matchesCount} {persons.Count}";
                Console.WriteLine(str);
            }
        }
    }
}
