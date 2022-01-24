using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            context.Database.EnsureCreated();

            //var jsonInput = File.ReadAllText("./../../../Datasets/suppliers.json");
            //var result = ImportSuppliers(context, jsonInput);

            //var jsonInput = File.ReadAllText("./../../../Datasets/parts.json");
            //var result = ImportParts(context, jsonInput);

            //var jsonInput = File.ReadAllText("./../../../Datasets/cars.json");
            //var result = ImportCars(context, jsonInput);

            //var jsonInput = File.ReadAllText("./../../../Datasets/customers.json");
            //var result = ImportCustomers(context, jsonInput);

            //var jsonInput = File.ReadAllText("./../../../Datasets/sales.json");
            //var result = ImportSales(context, jsonInput);

            //var jsonInput = File.ReadAllText("./../../../Datasets/sales.json");
            //var result = GetOrderedCustomers(context);

            //var result = GetOrderedCustomers(context);
            //var result = GetCarsFromMakeToyota(context);
            //var result = GetLocalSuppliers(context);
            //var result = GetCarsWithTheirListOfParts(context);
            //var result = GetTotalSalesByCustomer(context);
            var result = GetSalesWithAppliedDiscount(context);

            Console.WriteLine(result);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var export = context.Sales
                .Where(x => x.Car.Make == "Seat" || x.Car.Make == "Renault")
                .Select(x => new
                {
                    car = new
                    {
                        x.Car.Make,
                        x.Car.Model,
                        x.Car.TravelledDistance
                    },
                    CustomerName = x.Customer.Name,
                    x.Discount,
                    price = x.Car.PartCars.Select(pc => pc.Part.Price).Sum(),
                    priceWithDiscount = x.Car.PartCars.Select(pc => pc.Part.Price).Sum() - x.Discount * x.Car.PartCars.Count
                })
                .ToList();

            var serialized = JsonConvert.SerializeObject(export, Formatting.Indented);
            //File.AppendAllText("./../../../Datasets/sales-discounts.json, serialized);
            return serialized;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Select(s => s.Car.PartCars.Select(pc => pc.Part.Price).Sum()).Sum()
                })
                .OrderByDescending(x=> x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToList();

            var serialized = JsonConvert.SerializeObject(customers, Formatting.Indented);
            File.AppendAllText("./../../../Datasets/customers-total-sales.json", serialized);
            return serialized;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Opel")
                .Select(x => new
                {
                    car = new
                    {
                        x.Make,
                        x.Model,
                        x.TravelledDistance,
                    },
                    parts = x.PartCars.Select(c => new 
                    { 
                        c.Part.Name, 
                        c.Part.Price 
                    })
                })
                .ToList();

            var serialized = JsonConvert.SerializeObject(cars, Formatting.Indented);
            File.AppendAllText("./../../../Datasets/cars-and-parts.json", serialized);
            return serialized;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var result = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToList();

            var serialized = JsonConvert.SerializeObject(result, Formatting.Indented);
            File.AppendAllText("./../../../Datasets/local-suppliers.json", serialized);
            return serialized;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var result = context.Cars
                .Where(x => x.Make == "Toyota")
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToList();

            var serialized = JsonConvert.SerializeObject(result, Formatting.Indented);
            File.AppendAllText("./../../../Datasets/toyota-cars.json", serialized);
            return serialized;
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var result = context.Customers
                .Select(x => new
                {
                    x.Name,
                    x.BirthDate,
                    x.IsYoungDriver
                })
                .ToList();

            var serialized = JsonConvert.SerializeObject(result, Formatting.Indented);
            File.AppendAllText("./../../../Datasets/ordered-customers.json", serialized);
            return serialized;
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);
            context.AddRange(sales);
            context.SaveChanges();
            return $"Successfully imported {sales.Length}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);
            context.AddRange(customers);
            context.SaveChanges();
            return $"Successfully imported {customers.Length}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);

            var cars = new List<Car>();
            var carParts = new List<PartCar>();

            foreach (var carDto in carsDto)
            {
                var car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                foreach (int part in carDto.PartsId.Distinct())
                {
                    var carPart = new PartCar()
                    {
                        PartId = part,
                        Car = car
                    };

                    carParts.Add(carPart);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(carParts);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(x => context.Suppliers.Any(s => s.Id == x.SupplierId ))
                .ToList();

            context.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {parts.Count}.";
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);
            context.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Length}.";
        }

    }
}