using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF_Core_Advanced_Querying.Models
{
    public class Author
    {
        public Author()
        {
            this.Books = new HashSet<Book>();
        }

        public int Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
