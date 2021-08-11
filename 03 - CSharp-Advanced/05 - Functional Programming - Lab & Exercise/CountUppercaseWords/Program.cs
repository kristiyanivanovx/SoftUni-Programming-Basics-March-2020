using System;
using System.Linq;

namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> filter = word => char.IsUpper(word[0]);

            Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Where(filter)
                .ToList()
                .ForEach(w => Console.WriteLine(w));
        }
    }
}
