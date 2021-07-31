using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BooksLibrary
{
    public class LibraryIterator : IEnumerator<Book>
    {
        private List<Book> books;

        private int currentIndex;

        public LibraryIterator(IEnumerable<Book> books) // Book<T>
        {
            this.Reset();
            this.books = new List<Book>(books);
        }

        public Book Current => books[currentIndex];

        object IEnumerator.Current => this.Current;

        public void Dispose() 
        {
            this.books = null;
        }

        public bool MoveNext()
        {
            currentIndex += 1;
            return currentIndex < books.Count;
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }
    }
}