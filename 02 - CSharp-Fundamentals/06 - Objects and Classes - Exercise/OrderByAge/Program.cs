using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderByAge
{
    class Person
    {
        public Person(string name, int id, int age)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Id { get; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{this.Name} with ID: {this.Id} is {this.Age} years old.";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string command = Console.ReadLine();
            while (!command.Contains("End"))
            {
                var data = command.Split();
                var person = new Person(data[0], int.Parse(data[1]), int.Parse(data[2]));
                people.Add(person);
                command = Console.ReadLine();
            }

            people = people.OrderBy(x => x.Age).ToList();
            people.ForEach(x => Console.WriteLine(x));
        }
    }
}
