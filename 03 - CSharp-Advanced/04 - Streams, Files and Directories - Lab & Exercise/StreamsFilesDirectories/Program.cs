using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace StreamsFilesDirectories
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = "FileInput.txt";
            string pattern = @"[-,.!?]";

            using (StreamReader sr = new StreamReader(filepath))
            {
                string line = sr.ReadLine();
                int counter = 0;

                while (line != null)
                {
                    if (counter++ % 2 == 0)
                    {
                        string replacedLine = Regex.Replace(line, pattern, "@");
                        string[] words = replacedLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        Console.WriteLine(string.Join(" ", words.Reverse()));
                    }

                    line = sr.ReadLine();
                }
            }
        }
    }
}
