using System;
using System.Collections.Generic;

namespace SetsAndDictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Dictionary<string, int> studentsMarks = new Dictionary<string, int>();
            studentsMarks.Add("Pepo", 6);
            studentsMarks.Add("Gogo", 2);
            studentsMarks.Add("Ana", 3);

            Console.WriteLine(studentsMarks["Ana"]);

            foreach (KeyValuePair<string, int> item in studentsMarks)
            {
                Console.WriteLine($"{item.Key} has a mark of {item.Value}");
            }

            if (!studentsMarks.ContainsKey("Atanas"))
            {
                Console.WriteLine("adding atanas");
                studentsMarks.Add("Atanas", 4);
                Console.WriteLine(studentsMarks["Atanas"]);
            }

            studentsMarks.Remove("Atanas");

            foreach (KeyValuePair<string, int> item in studentsMarks)
            {
                Console.WriteLine($"{item.Key} has a mark of {item.Value}");
            }
        }
    }
}
