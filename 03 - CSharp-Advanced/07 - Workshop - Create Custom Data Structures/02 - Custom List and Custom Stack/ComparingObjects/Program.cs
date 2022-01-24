using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>();
            string[] input = Console.ReadLine().Split();
            int matchesCount = 0;

            while (input[0] != "END")
            {
                Person p = new Person(input[0], int.Parse(input[1]), input[2]);
                personList.Add(p);
                input = Console.ReadLine().Split();
            }

            int position = int.Parse(Console.ReadLine());

            for (int person = 0; person < personList.Count; person++)
            {
                if (personList[position - 1].CompareTo(personList[person]) == 0)
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
                string str = $"{matchesCount} {personList.Count - matchesCount} {personList.Count}";
                Console.WriteLine(str);
            }
        }
    }
}
