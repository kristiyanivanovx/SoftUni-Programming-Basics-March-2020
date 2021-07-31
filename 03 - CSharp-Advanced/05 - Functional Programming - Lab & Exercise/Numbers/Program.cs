using System;
using System.Linq;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 3, 5, 7, 9, 1, 2, 4, 6, 8 };
            array = array.OrderBy(x => x).ToArray();
            Console.WriteLine(string.Join(" ", array));
        }
    }
}
