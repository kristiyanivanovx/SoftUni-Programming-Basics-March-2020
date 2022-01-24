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
            ListyIterator<string> lisyIterator = new ListyIterator<string>();

            while (command[0] != "END")
            {
                if (command[0] == "Create")
                {
                    string[] collection = command.Where(x => x != "Create").ToArray();
                    lisyIterator.Create(collection);
                }
                else if (command[0] == "Print")
                {
                    lisyIterator.Print();
                }
                else if (command[0] == "PrintAll")
                {
                    lisyIterator.PrintAll();
                }
                else if (command[0] == "HasNext")
                {
                    Console.WriteLine(lisyIterator.HasNext());
                }
                else if (command[0] == "Move")
                {
                    Console.WriteLine(lisyIterator.Move());
                }

                command = Console.ReadLine().Split();
            }
        }
    }
}
