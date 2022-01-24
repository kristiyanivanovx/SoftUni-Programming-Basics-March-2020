using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inventory = new List<string>();
            string[] journal = Console.ReadLine().Split(", ");
            string command = Console.ReadLine();

            journal.ToList().ForEach(x => inventory.Add(x));

            while (!command.Contains("Craft!"))
            {
                var data = command.Split(" - ");
                var type = data[0];
                var item = data[1];

                if (type == "Collect")
                {
                    if (!inventory.Contains(item))
                    {
                        inventory.Add(item);
                    }
                }
                else if (type == "Drop")
                {
                    if (inventory.Contains(item))
                    {
                        inventory.Remove(item);
                    }
                }
                else if (type == "Combine Items")
                {
                    string[] items = item.Split(":");
                    var old = items[0];
                    string @new = items[1];

                    if (inventory.Contains(old))
                    {
                        var index = inventory.IndexOf(old);
                        inventory.Insert(index + 1, @new);
                    }
                }
                else if (type == "Renew")
                {
                    if (inventory.Contains(item))
                    {
                        var index = inventory.IndexOf(item);
                        inventory.Remove(item);
                        inventory.Add(item);
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", inventory));
        }
    }
}
