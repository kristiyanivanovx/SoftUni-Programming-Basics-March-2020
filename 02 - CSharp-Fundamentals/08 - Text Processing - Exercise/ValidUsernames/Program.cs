using System;
using System.Linq;

namespace ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] acceptable = new string[] {
                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
                "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
                "_", "-"
            };
            string[] input = Console.ReadLine().Split(", ");

            input.ToList().ForEach(x =>
            {
                bool flag = true;
                if (x.Length > 2 && x.Length <= 16)
                {
                    x.ToList().ForEach(e =>
                    {
                        if (!acceptable.Contains(e.ToString().ToUpper()))
                        {
                            flag = false;
                        }
                    });

                    if (flag)
                    {
                        Console.WriteLine(x);
                    }
                }
            });
        }
    }
}