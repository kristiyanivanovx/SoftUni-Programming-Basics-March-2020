using System;
using System.Collections.Generic;
using System.Text;

namespace BooksLibrary
{
    public class BookComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.CompareTo(y);
        }
    }
}
