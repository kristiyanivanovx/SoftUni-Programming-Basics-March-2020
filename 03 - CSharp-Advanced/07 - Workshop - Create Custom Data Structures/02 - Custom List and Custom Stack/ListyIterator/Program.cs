using System;
using System.Linq;
using System.Collections.Generic;

namespace ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split();
            ListyIterator<string> listy = new ListyIterator<string>();

            while (command[0] != "END")
            {
                if (command[0] == "Create")
                {
                    string[] sub = command.Where(x => x != "Create").ToArray();
                    listy.Create(sub);
                }

                if (command[0] == "Print")
                {
                    listy.Print();
                }

                if (command[0] == "PrintAll")
                {
                    listy.PrintAll();
                }

                if (command[0] == "HasNext")
                {
                    Console.WriteLine(listy.HasNext());
                }

                if (command[0] == "Move")
                {
                    Console.WriteLine(listy.Move());
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine("******************************");

            foreach (var item in listy)
            {
                Console.WriteLine(item);
            }
        }
    }
}
