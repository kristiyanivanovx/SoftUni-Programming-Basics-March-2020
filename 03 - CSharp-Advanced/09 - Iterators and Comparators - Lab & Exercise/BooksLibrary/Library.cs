using System.Collections;
using System.Collections.Generic;

namespace BooksLibrary
{
    public class Library : IEnumerable<Book>
    {
        private readonly SortedSet<Book> books;

        public Library() 
        {
            IComparer<Book> comparer = new BookComparer();
            this.books = new SortedSet<Book>(comparer);
        }

        public Library(params Book[] booksArray) // IEnumerable<Book> booksArray
        {
            IComparer<Book> comparer = new BookComparer();
            this.books = new SortedSet<Book>(booksArray, comparer);
        }

        //public void AddBook(T book)
        //{
        //    this.books.Add(book);
        //}

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);

            //foreach (var book in books)
            //{
            //    yield return book;
            //}
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
