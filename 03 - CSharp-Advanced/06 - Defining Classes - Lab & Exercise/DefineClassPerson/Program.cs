using System;

namespace DefineClassPerson
{
    public class Program
    {
        public static void Main()
        {
            //3
            //Pesho 3
            //Gosho 4
            //Annie 5

            //Annie 5

            //5
            //Steve 10
            //Christopher 15
            //Annie 4
            //Ivan 35
            //Maria 34

            //Ivan 35

            int n = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ");

                string name = input[0];
                int age = int.Parse(input[1]);

                Person currPerson = new Person(name, age);
                family.AddMember(currPerson);
            }

            Person oldestMember = family.GetOldestMember();
            Console.WriteLine(oldestMember.Name + " " + oldestMember.Age);
        }
    }
}
