using CarDealer.Data;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using AutoMapper;
using System.Collections.Generic;
using CarDealer.Dtos.Export;
using CarDealer.XmlFacade;

namespace CarDealer
{
    public class StartUp
    {
        public static IMapper mapper;

        public static void Main(string[] args)
        {
            InitializeAutoMapper();

            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var supplierXml = File.ReadAllText("./Datasets/suppliers.xml");
            //ImportSuppliers(context, supplierXml);

            //var partsXml = File.ReadAllText("./Datasets/parts.xml");
            //ImportParts(context, partsXml);

            //var carsXml = File.ReadAllText("./Datasets/cars.xml");
            //ImportCars(context, carsXml);

            //var customersXml = File.ReadAllText("./Datasets/customers.xml");
            //ImportCustomers(context, customersXml);

            //var salesXml = File.ReadAllText("./Datasets/sales.xml");
            //var resultSales = ImportSales(context, salesXml);

            //var resultCars = GetCarsWithDistance(context);
            //var resultCars = GetCarsFromMakeBmw(context);
            //var resultLocal = GetLocalSuppliers(context);
            //var resultCarList = GetCarsWithTheirListOfParts(context);
            //var salesResult = GetTotalSalesByCustomer(context);
            var salesResult = GetSalesWithAppliedDiscount(context);

            Console.WriteLine(salesResult);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new SaleWithDiscountOutputModel
                {
                    Car = new CarSaleOutputModel
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance,
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount = s.Car.PartCars.Sum(pc => pc.Part.Price) -
                                s.Car.PartCars.Sum(pc => pc.Part.Price) * s.Discount / 100m
                })
                .ToArray();

            var result = XmlConverter.Serialize(sales, "sales");
            return result;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(x => x.Sales.Count > 0)
                .Select(x => new CustomerCarsBoughtOutputModel
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count(),
                    SpentMoney = x.Sales.Select(s => s.Car.PartCars.Select(pc => pc.Part.Price).Sum()).Sum()
                    //SpentMoney = x.Sales.Select(s => s.Car)
                    //                    .SelectMany(c => c.PartCars)
                    //                    .Sum(pc => pc.Part.Price)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomerCarsBoughtOutputModel[]), new XmlRootAttribute("customers"));
            var stringWriter = new StringWriter();

            xmlSerializer.Serialize(stringWriter, customers);
            var result = stringWriter.ToString();

            //var result = XmlConverter.Serialize(customers, "customers");

            return result;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .Select(x => new CarWithPartsOutputModel
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.PartCars.Select(pc => new PartsOutputModel
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarWithPartsOutputModel[]), new XmlRootAttribute("cars"));
            var stringWriter = new StringWriter();

            xmlSerializer.Serialize(stringWriter, carsWithParts);
            var result = stringWriter.ToString();

            //var result = XmlConverter.Serialize(carsWithParts, "cars");

            return result;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new SupplierOutputModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SupplierOutputModel[]), new XmlRootAttribute("suppliers"));
            var stringWriter = new StringWriter();

            xmlSerializer.Serialize(stringWriter, suppliers);
            var res = stringWriter.ToString();

            return res;
        }
        
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var carsBMW = context.Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new BmwOutputModel
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();
            
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BmwOutputModel[]), new XmlRootAttribute("cars"));
            var stringWriter = new StringWriter();

            xmlSerializer.Serialize(stringWriter, carsBMW);
            var res = stringWriter.ToString();
            
            return res;
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2_000_000)
                .Select(c => new CarOutputModel 
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarOutputModel[]), new XmlRootAttribute("Cars"));
            var stringWriter = new StringWriter();

            xmlSerializer.Serialize(stringWriter, cars);
            var res = stringWriter.ToString();

            return res;
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaleInputModel[]), new XmlRootAttribute("Sales"));
            var stringRead = new StringReader(inputXml);
            var salesDto = xmlSerializer.Deserialize(stringRead) as SaleInputModel[];

            var carsId = context.Cars.Select(x => x.Id).ToList();
            var sales = salesDto.Where(x => carsId.Contains(x.CarId))
                                .Select(x => new Sale 
                                { 
                                    CarId = x.CarId,
                                    CustomerId = x.CustomerId,
                                    Discount = x.Discount 
                                })
                                .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}"; 
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomerInputModel[]), new XmlRootAttribute("Customers"));
            var stringRead = new StringReader(inputXml);
            var customersDto = xmlSerializer.Deserialize(stringRead) as CustomerInputModel[];

            //var customers = customersDto.Select(x => new Customer
            //{
            //    Name = x.Name,
            //    BirthDate = x.BirthDate,
            //    IsYoungDriver = x.IsYoungDriver
            //})
            //.ToList();

            var customersWithMapper = mapper.Map<Customer[]>(customersDto);

            context.Customers.AddRange(customersWithMapper);
            context.SaveChanges();

            return $"Successfully imported {customersWithMapper.Length}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarInputModel[]), new XmlRootAttribute("Cars"));
            var stringRead = new StringReader(inputXml);

            var carsDto = xmlSerializer.Deserialize(stringRead) as CarInputModel[];
            var allParts = context.Parts.Select(x => x.Id).ToList();
            var cars = new List<Car>();

            foreach (var currentCar in carsDto)
            {
                var distinctParts = currentCar.CarPartsInputModel.Select(x => x.Id).Distinct();
                var parts = distinctParts.Intersect(allParts);

                var car = new Car
                {
                    Make = currentCar.Make,
                    Model = currentCar.Model,
                    TravelledDistance = currentCar.TraveledDistance,
                };

                foreach (var part in parts)
                {
                    var partCar = new PartCar { PartId = part };
                    car.PartCars.Add(partCar);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PartInputModel[]), new XmlRootAttribute("Parts"));
            var stringRead = new StringReader(inputXml);
            var partsDto = xmlSerializer.Deserialize(stringRead) as PartInputModel[];

            var supplierIds = context.Suppliers.Select(x => x.Id).ToList();

            var parts = partsDto
                .Where(x => supplierIds.Contains(x.SupplierId))
                .Select(x => new Part
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    SupplierId = x.SupplierId
                })
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SupplierInputModel[]), new XmlRootAttribute("Suppliers"));
            var stringRead = new StringReader(inputXml);
            var suppliersDto = xmlSerializer.Deserialize(stringRead) as SupplierInputModel[];

            var suppliers = suppliersDto.Select(x => new Supplier
            {
                Name = x.Name,
                IsImporter = x.IsImporter
            })
            .ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}"; ;
        }

        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());
            mapper = config.CreateMapper();
        }
    }
}