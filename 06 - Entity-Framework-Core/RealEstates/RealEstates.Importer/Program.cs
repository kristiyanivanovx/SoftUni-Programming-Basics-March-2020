using RealEstates.Services;
using System;
using RealEstates.Services.Interfaces;
using RealEstates.Data;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

namespace RealEstates.Importer
{
    public class Program
    {
        static void Main(string[] args)
        {
            ImportJsonFile("imot.bg-houses-Sofia-raw-data-2021-03-18.json");
            Console.WriteLine();
            ImportJsonFile("imot.bg-raw-data-2021-03-18.json");
        }

        public static void ImportJsonFile(string fileName)
        {
            var context = new ApplicationDbContext();
            IPropertiesService propertiesService = new PropertiesService(context);
            var properties = JsonSerializer.Deserialize<IEnumerable<PropertyAsJson>>(File.ReadAllText(fileName));

            foreach (var jsonProp in properties)
            {
                propertiesService.Add(jsonProp.District, jsonProp.Price, jsonProp.Floor,
                    jsonProp.TotalFloors, jsonProp.Size, jsonProp.YardSize,
                    jsonProp.Year, jsonProp.Type, jsonProp.BuildingType);
                Console.WriteLine(".");
            }
        }
    }
}
