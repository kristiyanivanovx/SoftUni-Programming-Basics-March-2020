using System;
using System.Collections.Generic;
using System.Linq;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            // task 2
            List<string> first = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            if (first.Count != 5)
            {
                first.Add(string.Empty);
            }

            TupleCustom<string, string, string> tuple1
                = new TupleCustom<string, string, string>($"{first[0]} {first[1]}", first[2], $"{first[3]} {first[4]}");

            string[] second = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (second[2] == "drunk")
            {
                second[2] = "True";
            }

            if (second[2] == "not")
            {
                second[2] = "False";
            }

            TupleCustom<string, double, string> tuple2
                = new TupleCustom<string, double, string>(second[0], double.Parse(second[1]), second[2]);

            string[] third = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            TupleCustom<string, double, string> tuple3
                = new TupleCustom<string, double, string>(third[0], double.Parse(third[1]), third[2]);

            Console.WriteLine($"{tuple1.First} -> {tuple1.Second} -> {tuple1.Third}");
            Console.WriteLine($"{tuple2.First} -> {tuple2.Second} -> {tuple2.Third}");
            Console.WriteLine($"{tuple3.First} -> {tuple3.Second} -> {tuple3.Third}");

            // task 1
            //string[] first = Console.ReadLine().Split();

            //TupleCustom<string, string, string> tuple1 
            //    = new TupleCustom<string, string, string>(first[0], first[1], first[2]);

            //string[] second = Console.ReadLine().Split();
            //TupleCustom<string, int> tuple2 
            //    = new TupleCustom<string, int>(second[0], int.Parse(second[1]));

            //string[] third = Console.ReadLine().Split();
            //TupleCustom<int, double> tuple3 
            //    = new TupleCustom<int, double>(int.Parse(third[0]), double.Parse(third[1]));

            //Console.WriteLine($"{tuple1.First} {tuple1.Second} -> {tuple1.Third}");
            //Console.WriteLine($"{tuple2.First} -> {tuple2.Second}");
            //Console.WriteLine($"{tuple3.First} -> {tuple3.Second}");
        }
    }
}
