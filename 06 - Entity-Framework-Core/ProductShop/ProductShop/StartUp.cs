using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var context = new ProductShopContext();
            //var inputJson = File.ReadAllText("./../../../Datasets/users.json");
            //var result = ImportUsers(context, inputJson);
            //var inputJson = File.ReadAllText("./../../../Datasets/products.json");
            //var result = ImportProducts(context, inputJson);
            //var inputJson = File.ReadAllText("./../../../Datasets/categories.json");
            //var result = ImportCategories(context, inputJson);
            //var inputJson = File.ReadAllText("./../../../Datasets/categories-products.json");
            //var result = ImportCategoryProducts(context, inputJson);
            //var result = GetCategoriesByProductsCount(context);
            var result = GetUsersWithProducts(context);

            Console.WriteLine(result);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Count() > 0)
                .OrderByDescending(x => x.ProductsSold.Count)
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    age = x.Age,
                    soldProducts = new
                    {
                        count = x.ProductsSold.Count(),
                        products = x.ProductsSold.Select(p => new
                        {
                            name = p.Name,
                            price = p.Price.ToString("f2")
                        })
                    }
                })
                .ToList();

            var usersOutput = new { usersCount = users.Count, users };
            var result = JsonConvert.SerializeObject(usersOutput, Formatting.Indented);
            File.AppendAllText("./../../../users-and-products.json", result);
            return result;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count,
                    averagePrice = x.CategoryProducts.Select(p => p.Product.Price).DefaultIfEmpty(0).Average().ToString("f2"),
                    totalRevenue = x.CategoryProducts.Select(p => p.Product.Price).Sum()
                })
                .OrderByDescending(x => x.productsCount)
                .ToList();

            var result = JsonConvert.SerializeObject(categories, Formatting.Indented);
            File.AppendAllText("./../../../categories-by-products.json", result);
            return result;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context.Users
                .Where(x => x.ProductsSold.Count > 0)
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold.Select(p => new 
                    { 
                        name = p.Name, 
                        price = p.Price, 
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName
                    })
                    .ToList()
                })
                .OrderBy(x => x.lastName)
                .ThenBy(x => x.firstName)
                .ToList();

            var result = JsonConvert.SerializeObject(soldProducts, Formatting.Indented);
            File.AppendAllText("./../../../Datasets/users-sold-products.json", result);
            return result;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(x => new
                {
                    name = x.Name,
                    price = x.Price.ToString("f2"),
                    seller = $"{x.Seller.FirstName} {x.Seller.LastName}"
                })
                .ToList();

            var result = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText("./../../../Datasets/products-in-range.json", result);
            return result;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);
            context.AddRange(categoryProducts);
            context.SaveChanges();
            return $"Successfully imported {categoryProducts.Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson);
            context.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);
            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);
            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Length}";
        }
    }
}