using System;

namespace IteratorsAndComparators
{
    class Program
    {
        static void Main()
        {
            PrintNames("Gosho", "Pesho");
        }

        public static void PrintNames(params string [] names)
        {
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }
    }
}
