using EF_Core_Advanced_Querying.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_Advanced_Querying.Data
{
    public class BookShopContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookCategory> BookCategories { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=BookShop;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCategory>()
                .HasKey(x => new { x.BookId, x.CategoryId });
        }
    }
}
