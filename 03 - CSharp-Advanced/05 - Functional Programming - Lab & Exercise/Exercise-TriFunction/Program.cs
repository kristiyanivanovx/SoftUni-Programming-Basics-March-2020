using System;
using System.Linq;

namespace Exercise_TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
            Func<string, int, bool> triFunction = (string name, int sum) => name.Sum(x => x) >= sum;
            PrintOutput(triFunction, names, number);
        }

        static void PrintOutput(Func<string, int, bool> function, string[] names, int number)
        {
            string name = names.FirstOrDefault(name => function(name, number));
            if (name != null)
            {
                Console.WriteLine(name);
            }
        }
    }
}
