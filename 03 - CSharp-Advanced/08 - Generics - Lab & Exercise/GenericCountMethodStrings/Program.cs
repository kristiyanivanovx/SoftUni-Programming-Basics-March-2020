using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            //List<Box<string>> list = new List<Box<string>>();
            List<Box<double>> list = new List<Box<double>>();

            for (int i = 0; i < n; i++)
            {
                //string input = Console.ReadLine();
                double input = double.Parse(Console.ReadLine());
                list.Add(new Box<double>(input));
            }

            Box<double> box = new Box<double>(double.Parse(Console.ReadLine()));

            var result = CountMethodStrings(list, box);
            Console.WriteLine(result);
        }

        private static int CountMethodStrings<T>(List<Box<T>> boxes, Box<T> box)
             where T : IComparable
        {
            List<Box<T>> count = boxes.Where(x => x.Value.CompareTo(box.Value) > 0).ToList();
            return count.Count;
        }
    }
}
