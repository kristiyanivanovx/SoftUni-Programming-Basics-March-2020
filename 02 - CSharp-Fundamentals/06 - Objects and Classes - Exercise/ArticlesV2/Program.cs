using System;
using System.Collections.Generic;
using System.Linq;

namespace ArticlesV2
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

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();
            int value = int.Parse(Console.ReadLine());

            for (int i = 0; i < value; i++)
            {
                string[] commandData = Console.ReadLine().Split(", ");
                Article article = new Article(commandData[0], commandData[1], commandData[2]);
                articles.Add(article);
            }

            string criteria = Console.ReadLine();
            if (criteria == "title")
            {
                articles = articles.OrderBy(x => x.Title).ToList();
            }
            else if (criteria == "content")
            {
                articles = articles.OrderBy(x => x.Content).ToList();
            }
            else if (criteria == "author")
            {
                articles = articles.OrderBy(x => x.Author).ToList();
            }

            articles.ForEach(x => Console.WriteLine($"{x.Title} - {x.Content}: {x.Author}"));
        }
    }
}
