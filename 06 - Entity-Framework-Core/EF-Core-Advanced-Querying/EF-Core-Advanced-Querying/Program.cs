using EF_Core_Advanced_Querying.Data;
using EF_Core_Advanced_Querying.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;

namespace BookShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new BookShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            //var input = "teEN";

            //AgeRestriction ageRestriction = (AgeRestriction) Enum.Parse(typeof(AgeRestriction), "miNor", true);
            //var result = GetBooksByAgeRestriction(context, ageRestriction);
            //var result = GetGoldenBooks(context);
            //var result = GetBooksByPrice(context);
            //var result = GetBooksNotReleasedIn(context, 2000);
            //var result = GetBooksNotReleasedIn(context, 1998);

            //var categoriesAsString = "horror mystery drama";
            //var result = GetBooksByCategory(context, categoriesAsString);

            //var result = GetBooksReleasedBefore(context, "12-04-1992"); 
            //var result = GetBooksReleasedBefore(context, "30-12-1989"); 

            //var result = GetAuthorNamesEndingIn(context, "e"); 
            //var result = GetAuthorNamesEndingIn(context, "dy"); 

            //var result = GetBookTitlesContaining(context, "sK"); // "WOR" 
            //var result = GetBooksByAuthor(context, "R"); // "po" 
            //var result = CountBooks(context, 12); // 40
            //var result = CountCopiesByAuthor(context);
            //var result = GetTotalProfitByCategory(context);
            //var result = GetMostRecentBooks(context);
            //IncreasePrices(context);
            var result = RemoveBooks(context);

            Console.WriteLine(result);
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var countRemoved = context.Books
                .Where(x => x.Copies < 4200).Count();

            var books = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();

            context.RemoveRange(books);
            context.SaveChanges();

            return countRemoved;
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var result = context.Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                    RecentBooks = x.CategoryBooks
                        .Select(x => new 
                        {
                            x.Book.Title, 
                            x.Book.ReleaseDate.Value 
                        })
                        .OrderByDescending(x => x.Value)
                        .Take(3)
                        .ToList()
                })
                .OrderBy(x => x.CategoryName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var info in result)
            {
                sb.AppendLine($"--{info.CategoryName}");

                foreach (var item in info.RecentBooks)
                {
                    sb.AppendLine($"{item.Title} ({item.Value.Year})");
                }
            }

            return sb.ToString().Trim();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var result = context.Categories
                .Select(x => new
                {
                    x.Name,
                    Profit = x.CategoryBooks.Select(x => x.Book.Price * x.Book.Copies).Sum()
                })
                .OrderByDescending(x => x.Profit)
                .ThenBy(x => x.Name);

            StringBuilder sb = new StringBuilder();

            foreach (var info in result)
            {
                sb.AppendLine($"{info.Name} ${info.Profit}");
            }

            return sb.ToString().Trim();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            //var result = context.Books
            //    .Include(x => x.Author)
            //    .Include(x => x.BookCategories)
            //    .Select(x => new
            //    {
            //        AuthorFirstName = x.Author.FirstName,
            //        AuthorLastName = x.Author.LastName,
            //        BooksCopiesSum = x.BookCategories.Select(x => x.Book.Copies).Sum()
            //    })
            //    .OrderByDescending(x => x.BooksCopiesSum)
            //    .ToList();

            //StringBuilder sb = new StringBuilder();

            //foreach (var info in result)
            //{

            //    sb.AppendLine($"{info.AuthorFirstName} {info.AuthorLastName} - {info.BooksCopiesSum}");
            //}

            //return sb.ToString().Trim();

            var result = context.Authors
               .Select(x => new
               {
                   x.FirstName,
                   x.LastName,
                   TotalCopies = x.Books.Sum(b => b.Copies)
               })
               .OrderByDescending(x => x.TotalCopies)
               .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var info in result)
            {

                sb.AppendLine($"{info.FirstName} {info.LastName} - {info.TotalCopies}");
            }

            return sb.ToString().Trim();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .Count();

            return books;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(x => new
                {
                    x.Id,
                    x.Title,
                    AuthorFirstName = x.Author.FirstName,
                    AuthorLastName = x.Author.LastName
                })
                .OrderBy(x => x.Id)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                string authorFullName = $"{book.AuthorFirstName} {book.AuthorLastName}";
                sb.AppendLine($"{book.Title} ({authorFullName})");
            }

            return sb.ToString().Trim();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var result = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            var output = string.Join(Environment.NewLine, result);
            return output;
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => new { x.FirstName, x.LastName })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName}");
            }

            return sb.ToString().Trim();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var result = context.Books
                .Where(x => x.ReleaseDate.Value < DateTime.Parse(date))
                .Select(x => new { x.Title, x.EditionType, x.Price, x.ReleaseDate })
                .OrderByDescending(x => x.ReleaseDate)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in result)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categoriesAsArray = input
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var books = context.Books
                .Include(x => x.BookCategories)
                .ThenInclude(x => x.Category)
                .Where(x => x.BookCategories
                    .Any(x => categoriesAsArray
                        .Contains(x.Category.Name.ToLower())))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            var result = string.Join(Environment.NewLine, books);
            return result;
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .Select(x => new { x.Id, x.Title })
                .OrderBy(x => x.Id)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().Trim();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Price > 40)
                .Select(x => new { x.Title, x.Price })
                .OrderByDescending(x => x.Price)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var result = context.Books
                .Where(x => x.EditionType == EditionType.Gold && x.Copies < 5000)
                .Select(x => new { x.Id, x.Title })
                .OrderBy(x => x.Id)
                .ToList();

            var stringResult = string.Join(Environment.NewLine, result);
            return stringResult;
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, AgeRestriction command)
        {
            var result = context.Books
                .Where(x => x.AgeRestriction == command)
                .Select(x => x.Title)
                .OrderBy(t => t)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var bookTitle in result)
            {
                sb.AppendLine(bookTitle);
            }

            return sb.ToString().Trim();
        }
    }
}
