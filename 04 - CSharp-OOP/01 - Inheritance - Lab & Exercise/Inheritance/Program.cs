using System;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Child child = new Child(name, age);
            Console.WriteLine(child);

            Child child2 = new Child(name, age + 2);
            Console.WriteLine(child2);
        }
    }
}
