using DefineClassPerson;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpinionPoll
{
    public class Program
    {
        static void Main(string[] args)
        {
            //5
            //Nikolai 33
            //Yordan 88
            //Tosho 22
            //Lyubo 44
            //Stanislav 11

            //Lyubo - 44
            //Nikolai - 33
            //Yordan - 88

            int n = int.Parse(Console.ReadLine());

            List<Person> personList = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine().Split(" ");

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                Person person = new Person(name, age);

                personList.Add(person);
            }

            personList = personList.Where(p => p.Age > 30)
                                    .OrderBy(p => p.Name)
                                    .ToList();

            foreach (Person person in personList)
            {
                Console.WriteLine(person.Name + " - " + person.Age);
            }
        }
    }
}
