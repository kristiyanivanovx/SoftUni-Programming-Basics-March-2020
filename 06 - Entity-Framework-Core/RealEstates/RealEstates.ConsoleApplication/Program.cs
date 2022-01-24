using Microsoft.EntityFrameworkCore;

using RealEstates.Data;
using RealEstates.Services;
using RealEstates.Services.Interfaces;
using RealEstates.Services.Models;

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace RealEstates.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            var context = new ApplicationDbContext();
            context.Database.Migrate();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Property search");
                Console.WriteLine("2. Most Expensive districts");
                Console.WriteLine("3. Average price per square meter");
                Console.WriteLine("4. Add tag");
                Console.WriteLine("5. Bulk tag to properties");
                Console.WriteLine("6. Property Full Info");
                Console.WriteLine("0. Exit");

                bool parsed = int.TryParse(Console.ReadLine(), out int option);
                if (parsed && option == 0)
                {
                    break;
                }

                if (parsed && (option >= 1 && option <= 6))
                {
                    switch (option)
                    {
                        case 1: 
                            PropertySearch(context);
                            break;
                        case 2:
                            MostExpensiveDistricts(context);
                            break;
                        case 3:
                            AveragePricePerSquareMeter(context);
                            break;
                        case 4:
                            AddTag(context);
                            break;
                        case 5:
                            BulkTagToPropertiesRelation(context);
                            break;
                        case 6:
                            PropertyFullInfo(context);
                            break;

                        default:
                            break;
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private static void PropertyFullInfo(ApplicationDbContext context)
        {
            Console.WriteLine("Count of properties");
            int count = int.Parse(Console.ReadLine());
            IPropertiesService propertiesService = new PropertiesService(context);
            var result = propertiesService.GetFullData(count).ToArray();

            var xmlSerializer = new XmlSerializer(typeof(PropertyInfoFullData[]));
            var stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, result);

            Console.WriteLine(stringWriter.ToString().TrimEnd());

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.DistrictName);
            //    foreach (var tag in item.Tags)
            //    {
            //        Console.WriteLine(tag.Name);
            //    }
            //}
            //throw new NotImplementedException();
        }

        // set better name
        private static void BulkTagToPropertiesRelation(ApplicationDbContext context)
        {
            Console.WriteLine("Bulk operation started.");

            IPropertiesService propertiesService = new PropertiesService(context);
            ITagService tagService = new TagService(context, propertiesService);
            tagService.BulkTagToPropertiesRelation();

            Console.WriteLine("Bulk operation finished.");
        }

        private static void AddTag(ApplicationDbContext context)
        {
            IPropertiesService propertiesService = new PropertiesService(context);

            Console.WriteLine("Tag name:");
            var tagName = Console.ReadLine();

            Console.WriteLine("Importance (optional):");
            bool isParsed = int.TryParse(Console.ReadLine(), out int tagImportance);
            int? importance = isParsed ? tagImportance : null;

            //var tags = new string[]
            //{
            //    "скъп-имот",
            //    "евтин-имот",
            //    "нов-имот",
            //    "стар-имот",
            //    "голям-имот",
            //    "малък-имот",
            //    "последен-етаж",
            //    "първи-етаж",
            //};

            ITagService tagService = new TagService(context, propertiesService);

            //foreach (var item in tags)
            //{
            //    var randomImportance = new Random().Next(0, 6);
            //    tagService.Add(item, randomImportance);
            //}

            tagService.Add(tagName, importance);
        }

        private static void AveragePricePerSquareMeter(ApplicationDbContext context)
        {
            IPropertiesService service = new PropertiesService(context);
            Console.WriteLine($"Average price per square meter: " + service.AveragePricePerSquareMeter() + "euro/square km");
        }

        private static void MostExpensiveDistricts(ApplicationDbContext context)
        {
            IDistrictsService districtsService = new DistrictService(context);
            var districts = districtsService.GetMostExpensiveDistricts(10);

            foreach (var district in districts)
            {
                Console.WriteLine($"{district.Name} => {district.AveragePricePerSquareMeter}€/m^2 ({district.PropertiesCount})");
            }
        }

        private static void PropertySearch(ApplicationDbContext context)
        {
            Console.Write("Min price:");
            int minPrice = int.Parse(Console.ReadLine());

            Console.Write("Max price:");
            int maxPrice = int.Parse(Console.ReadLine());

            Console.Write("Min size:");
            int minSize = int.Parse(Console.ReadLine());

            Console.Write("Max size:");
            int maxSize = int.Parse(Console.ReadLine());

            IPropertiesService service = new PropertiesService(context);
            var properties = service.Search(minPrice, maxPrice, minSize, maxSize);
            foreach (var property in properties)
            {
                Console.WriteLine($"{property.DistrictName}; {property.BuildingType}; {property.PropertyType} => {property.Price}€ => {property.Size}m^2");
            }
        }
    }
}
