using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("text.txt");
            string[] wordsWanted = File.ReadAllLines("words.txt");

            Dictionary<string, int> wordsCounts = new Dictionary<string, int>();

            foreach (var item in wordsWanted)
            {
                wordsCounts.Add(item.ToLower(), 0);
            }

            foreach (string line in lines)
            {
                string[] words = line.Split(new char[] { '-', ' ', '?', '!', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in words)
                {
                    string curentWord = word.ToLower();

                    if (wordsCounts.ContainsKey(curentWord))
                    {
                        wordsCounts[curentWord] += 1;
                    }
                }
            }

            Dictionary<string, int> sortedWords = wordsCounts
                .OrderByDescending(kvp => kvp.Value)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var sortedLine in sortedWords)
            {
                Console.WriteLine($"{sortedLine.Key} - {sortedLine.Value}");
                File.AppendAllText("actualResult.txt", $"{sortedLine.Key} - {sortedLine.Value}" + Environment.NewLine);
            }
        }
    }
}
