using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
	[XmlRoot(ElementName = "Users")]
	public class UsersAndProducts
	{
		[XmlElement(ElementName = "count")]
		public int Count { get; set; }

		[XmlElement(ElementName = "users")]
		public UsersLowercased Users { get; set; }
	}

	[XmlRoot(ElementName = "users")]
	public class UsersLowercased
	{
		[XmlElement(ElementName = "User")]
		public DistinctUser User { get; set; }
	}

	[XmlRoot(ElementName = "User")]
	public class DistinctUser
	{
		[XmlElement(ElementName = "firstName")]
		public string FirstName { get; set; }

		[XmlElement(ElementName = "lastName")]
		public string LastName { get; set; }

		[XmlElement(ElementName = "age")]
		public int? Age { get; set; }

		[XmlElement(ElementName = "SoldProducts")]
		public SoldProductsWithCount SoldProducts { get; set; }
	}

	[XmlRoot(ElementName = "SoldProducts")]
	public class SoldProductsWithCount
	{
		[XmlElement(ElementName = "count")]
		public int Count { get; set; }

		[XmlElement(ElementName = "products")]
		public Products Products { get; set; }
	}

	[XmlRoot(ElementName = "products")]
	public class Products
	{
		[XmlElement("Product")]
        public ProductInner[] ProductInner { get; set; }
    }

	[XmlRoot(ElementName = "Product")]
	public class ProductInner
    {
		[XmlElement(ElementName = "name")]
		public string Name { get; set; }

		[XmlElement(ElementName = "price")]
		public decimal Price { get; set; }
	}
}
