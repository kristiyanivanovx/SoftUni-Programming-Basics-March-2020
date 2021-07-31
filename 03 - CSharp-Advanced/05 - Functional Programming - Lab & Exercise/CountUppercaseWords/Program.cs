using System;
using System.Linq;

namespace CountUppercaseWords
{
    class Program
    {
        // The following example shows how to use Function
        // The
        // Function
        static void Main(string[] args)
        {
            // 3 exe

            //string[] word = Console.ReadLine().Split()
            //    //.Where(x => x.Is)
            //    //.Where((x, index) => x[index].IsUpper())
            //    .ToArray();

            Func<string, bool> filter = txt => Char.IsUpper(txt[0]);

            string[] words = Console.ReadLine()
                                    .Split()
                                    .Where(filter)
                                    .ToArray();

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
