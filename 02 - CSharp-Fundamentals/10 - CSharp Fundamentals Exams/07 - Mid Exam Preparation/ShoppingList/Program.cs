using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> groceries = new List<string>();
            string[] list = Console.ReadLine().Split("!");
            list.ToList().ForEach(x => groceries.Add(x));

            string command = Console.ReadLine();
            while (!command.Contains("Go Shopping!"))
            {
                var data = command.Split();
                var type = data[0];
                var item = data[1];

                if (type == "Urgent")
                {
                    if (!groceries.Contains(item))
                    {
                        groceries.Insert(0, item);
                    }
                }
                else if (type == "Unnecessary")
                {
                    if (groceries.Contains(item))
                    {
                        groceries.Remove(item);
                    }
                }
                else if (type == "Correct")
                {
                    if (groceries.Contains(item))
                    {
                        string grocery = groceries.FirstOrDefault(x => x == item);
                        var index = groceries.IndexOf(grocery);
                        groceries.RemoveAt(index);
                        groceries.Insert(index, data[2]);
                    }
                }
                else if (type == "Rearrange")
                {
                    if (groceries.Contains(item))
                    {
                        groceries.Remove(item);
                        groceries.Add(item);
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", groceries));
        }
    }
}
