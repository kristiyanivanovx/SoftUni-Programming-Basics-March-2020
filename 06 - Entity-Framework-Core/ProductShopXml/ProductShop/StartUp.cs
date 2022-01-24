using ProductShop.Data;
using System.IO;
using System.Xml.Serialization;
using ProductShop.Dtos.Import;
using System.Linq;
using ProductShop.Models;
using System;
using ProductShop.Dtos.Export;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var file1 = File.ReadAllText("./../../../Datasets/users.xml");
            //var resultUsers = ImportUsers(context, file1);

            //var file = File.ReadAllText("./../../../Datasets/products.xml");
            //var resProducts = ImportProducts(context, file);

            //var file2 = File.ReadAllText("./../../../Datasets/categories.xml");
            //var resCategories = ImportCategories(context, file2);

            //var file3 = File.ReadAllText("./../../../Datasets/categories-products.xml");
            //var resCategoriesProducts = ImportCategoryProducts(context, file3);

            //Console.WriteLine(resCategoriesProducts);

            //var result = GetProductsInRange(context);
            //var result = GetSoldProducts(context);

            //var result = GetCategoriesByProductsCount(context);
            var result = GetUsersWithProducts(context);

            Console.WriteLine(result);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .Select(x => new UsersAndProducts
                {
                    Count = context.Users.Count(),
                    Users = new UsersLowercased
                    {
                        User = new DistinctUser
                        {
                            FirstName = x.FirstName,
                            LastName = x.LastName,
                            Age = x.Age,
                            SoldProducts = new SoldProductsWithCount
                            {
                                Count = x.ProductsSold.Count(),
                                Products = new Products
                                {
                                    ProductInner = x.ProductsSold.Select(p => new ProductInner
                                    {
                                        Name = p.Name,
                                        Price = p.Price
                                    })
                                    .OrderByDescending(p => p.Price)
                                    .Take(10)
                                    .ToArray()
                                }
                            }
                        }
                    },
                })
                .OrderByDescending(x => x.Count)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UsersAndProducts[]), new XmlRootAttribute("Users"));
            var stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, users);

            var result = stringWriter.ToString();
            return result;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new CategoriesOutputModel
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count(),
                    //AveragePrice = 0m,
                    AveragePrice = x.CategoryProducts.Average(p => p.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoriesOutputModel[]), new XmlRootAttribute("Categories"));
            var stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, categories);

            var result = stringWriter.ToString();
            return result;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Count > 0)
                .Select(x => new UserOutputModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = new SoldProducts
                    {
                        Product = x.ProductsSold.Select(p => new ProductDetail 
                        { 
                            Name = p.Name, Price = p.Price 
                        })
                        .ToArray()
                    }
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserOutputModel[]), new XmlRootAttribute("Users"));
            var stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, users);

            var result = stringWriter.ToString();
            return result;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new ProductOutputModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = x.Buyer.FirstName != null ? $"{x.Buyer.FirstName} {x.Buyer.LastName}" : null
                })
                .OrderBy(x => x.Price)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProductOutputModel[]), new XmlRootAttribute("Products"));
            var stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, products);

            var result = stringWriter.ToString();
            return result;
        }

        // --- 

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoriesProductsInputModel[]), new XmlRootAttribute("CategoryProducts"));
            var stringRead = new StringReader(inputXml);
            var catPrDto = xmlSerializer.Deserialize(stringRead) as CategoriesProductsInputModel[];

            var validCategoriesIds = context.Categories.Select(x => x.Id).ToList();
            var validProductsIds = context.Products.Select(x => x.Id).ToList();

            var categoryProduct = catPrDto
                .Where(x => validCategoriesIds.Contains(x.CategoryId) && validProductsIds.Contains(x.ProductId))
                .Select(x => new CategoryProduct
                {
                    CategoryId = x.CategoryId,
                    ProductId = x.ProductId
                })
                .ToList();

            context.CategoryProducts.AddRange(categoryProduct);
            context.SaveChanges();

            return $"Successfully imported {categoryProduct.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoryInputModel[]), new XmlRootAttribute("Categories"));
            var stringRead = new StringReader(inputXml);
            var categoryDto = xmlSerializer.Deserialize(stringRead) as CategoryInputModel[];

            var category = categoryDto
                .Where(x => x.Name != null)
                .Select(x => new Category
            {
                Name = x.Name
            })
            .ToList();

            context.Categories.AddRange(category);
            context.SaveChanges();

            return $"Successfully imported {category.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProductInputModel[]), new XmlRootAttribute("Products"));
            var stringRead = new StringReader(inputXml);
            var productsDto = xmlSerializer.Deserialize(stringRead) as ProductInputModel[];

            var products = productsDto.Select(x => new Product
            {
                Name = x.Name,
                Price = x.Price,
                SellerId = x.SellerId,
                BuyerId = x.BuyerId
            })
            .ToList();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserInputModel[]), new XmlRootAttribute("Users"));
            var stringRead = new StringReader(inputXml);
            var usersDTO = xmlSerializer.Deserialize(stringRead) as UserInputModel[];

            var users = usersDTO.Select(x => new User
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Age = x.Age
            })
            .ToList();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
    }
}