using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BooksLibrary
{
    public class Book : IComparable<Book>
    {
        public string Title { get; private set; }

        public int Year { get; private set; }

        public List<string> Authors { get; private set; }

        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = new List<string>(authors);
        }

        public int CompareTo(Book other)
        {
            //return this.Year.CompareTo(other.Year);

            if (Year != other.Year)
            {
                return Year - other.Year;
            }

            return this.Title.CompareTo(other.Title);
        }

        public override string ToString()
        {
            //return $"{this.Title} {this.Year} {string.Join(" ", this.Authors)}";
            return $"{this.Title} {this.Year}";
        }
    }
}
