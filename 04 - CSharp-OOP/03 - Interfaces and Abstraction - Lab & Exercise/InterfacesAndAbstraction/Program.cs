using System;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            VersionTwoWithOnlyNameAndAge();
        }

        private static void VersionTwoWithOnlyNameAndAge()
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            IPerson person = new Citizen(name, age);

            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);

            // Input and Output are the same
            // Pesho
            // 25
        }
    }
}
