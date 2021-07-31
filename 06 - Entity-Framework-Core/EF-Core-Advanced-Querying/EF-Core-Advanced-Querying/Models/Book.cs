using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EF_Core_Advanced_Querying.Models.Enums;

namespace EF_Core_Advanced_Querying.Models
{
    public class Book
    {
        public Book()
        {
            this.BookCategories = new HashSet<BookCategory>();
        }

        public int Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int Copies { get; set; }

        public decimal Price { get; set; }

        public EditionType EditionType { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public ICollection<BookCategory> BookCategories { get; set; }
    }
}
