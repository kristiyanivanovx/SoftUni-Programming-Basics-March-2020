using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesDatabase.Data.Models
{
    public class Product
    {
        public Product()
        {
            this.Sales = new HashSet<Sale>();
        }

        public int ProductId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
