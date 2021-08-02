using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();
            while (!command.Contains("end"))
            {
                string[] data = command.Split();
                string type = data[0];
                int element = int.Parse(data[1]);

                if (type == "Insert")
                {
                    int position = int.Parse(data[2]);
                    list.Insert(position, element);
                }
                else if (type == "Delete")
                {
                    list.RemoveAll(x => x == element);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
