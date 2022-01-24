using System.Xml.Serialization;
using System.Collections.Generic;

namespace ProductShop.Dtos.Export
{
	[XmlType("User")]
	public class UserOutputModel
	{
		[XmlElement("firstName")]
		public string FirstName { get; set; }

		[XmlElement("lastName")]
		public string LastName { get; set; }

		[XmlElement("soldProducts")]
		public SoldProducts SoldProducts { get; set; }
	}

	[XmlType("soldProducts")]
	public class SoldProducts
	{
		[XmlElement("Product")]
		public ProductDetail[] Product { get; set; }
	}

	[XmlType("Product")]
	public class ProductDetail
	{
		[XmlElement("name")]
		public string Name { get; set; }

		[XmlElement("price")]
		public decimal Price { get; set; }
	}
}
