using System;
using System.Collections.Generic;
using System.Linq;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputSongs = Console.ReadLine().Split(", ").ToArray();
            Queue<string> songs = new Queue<string>(inputSongs);
            List<string> toBePrinted = new List<string>();

            while (songs.Any())
            {
                string command = Console.ReadLine();

                if (command.Contains("Play"))
                {
                    songs.Dequeue();
                }
                else if (command.Contains("Add"))
                {
                    string song = command.Substring(4);

                    if (songs.Contains(song))
                    {
                        toBePrinted.Add($"{song} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(song);
                    }
                }
                else if (command.Contains("Show"))
                {
                    toBePrinted.Add(string.Join(", ", songs));
                }
            }

            toBePrinted.Add("No more songs!");

            foreach (var element in toBePrinted)
            {
                Console.WriteLine(element);
            }
        }
    }
}