using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePianist
{
    class Piece
    {
        public Piece(string name, string composer, string key)
        {
            this.Name = name;
            this.Composer = composer;
            this.Key = key;
        }

        public string Name { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Piece> pieces = new List<Piece>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string piecesData = Console.ReadLine();
                string[] data = piecesData.Split("|");
                Piece piece = new Piece(data[0], data[1], data[2]);
                pieces.Add(piece);
            }

            string command = Console.ReadLine();
            while (!command.Contains("Stop"))
            {
                string[] data = command.Split("|");
                string type = data[0];
                if (type == "Add")
                {
                    string name = data[1];
                    string composer = data[2];
                    string key = data[3];

                    Piece existingPiece = pieces.FirstOrDefault(x => x.Name == name);
                    if (existingPiece != null)
                    {
                        Console.WriteLine($"{existingPiece.Name} is already in the collection!");
                    }
                    else
                    {
                        Piece newPiece = new Piece(name, composer, key);
                        pieces.Add(newPiece);
                        Console.WriteLine($"{name} by {composer} in {key} added to the collection!");
                    }
                }
                else if (type == "Remove")
                {
                    string name = data[1];
                    Piece existingPiece = pieces.FirstOrDefault(x => x.Name == name);
                    if (existingPiece != null)
                    {
                        pieces.Remove(existingPiece);
                        Console.WriteLine($"Successfully removed {name}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {name} does not exist in the collection.");
                    }
                }
                else if (type == "ChangeKey")
                {
                    string name = data[1];
                    string newKey = data[2];
                    Piece existingPiece = pieces.FirstOrDefault(x => x.Name == name);
                    if (existingPiece != null)
                    {
                        existingPiece.Key = newKey;
                        Console.WriteLine($"Changed the key of {name} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {name} does not exist in the collection.");
                    }
                }

                command = Console.ReadLine();
            }

            pieces = pieces.OrderBy(x => x.Name).ThenBy(x => x.Composer).ToList();
            pieces.ForEach(x => Console.WriteLine($"{x.Name} -> Composer: {x.Composer}, Key: {x.Key}"));
        }
    }
}
