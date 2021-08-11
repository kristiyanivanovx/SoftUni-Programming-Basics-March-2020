using System;
using System.Collections.Generic;
using System.Linq;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            TupleCustom<string, string, string> firstTuple = new TupleCustom<string, string, string>($"{firstInput[0]} {firstInput[1]}", firstInput[2], firstInput[3]);
            Console.WriteLine(firstTuple);

            string[] secondInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string drunkOrNot = secondInput[2] == "drunk" ? "True" : "False";
            TupleCustom<string, double, string> secondTuple= new TupleCustom<string, double, string>(secondInput[0], int.Parse(secondInput[1]), drunkOrNot);
            Console.WriteLine(secondTuple);

            string[] thirdInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            TupleCustom<string, double, string> thirdTuple= new TupleCustom<string, double, string>(thirdInput[0], double.Parse(thirdInput[1]), thirdInput[2]);
            Console.WriteLine(thirdTuple);

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
