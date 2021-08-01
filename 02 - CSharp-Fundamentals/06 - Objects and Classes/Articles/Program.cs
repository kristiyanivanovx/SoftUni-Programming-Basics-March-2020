using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles
{
    class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public void Edit(string content)
        {
            this.Content = content;
        }

        public void ChangeAuthor(string author)
        {
            this.Author = author;
        }

        public void Rename(string title)
        {
            this.Title = title;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<string> data = Console.ReadLine().Split(", ").ToList();
            int value = int.Parse(Console.ReadLine());

            Article article = new Article(data[0], data[1], data[2]);

            for (int i = 0; i < value; i++)
            {
                string[] commandData = Console.ReadLine().Split(": ");
                if (commandData[0] == "Edit")
                {
                    article.Edit(commandData[1]);
                }
                else if (commandData[0] == "ChangeAuthor")
                {
                    article.ChangeAuthor(commandData[1]);
                }
                else if (commandData[0] == "Rename")
                {
                    article.Rename(commandData[1]);
                }
            }

            Console.WriteLine(article.ToString());
        }
    }
}
