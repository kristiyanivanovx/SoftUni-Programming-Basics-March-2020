using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF_Core_Advanced_Querying.Models
{
    public class Category
    {
        public Category()
        {
            this.CategoryBooks = new HashSet<BookCategory>();
        }

        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<BookCategory> CategoryBooks { get; set; }
    }
}
