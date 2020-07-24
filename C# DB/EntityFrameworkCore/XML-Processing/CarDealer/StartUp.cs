using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using ProductShop.XmlHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();

            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //ImportSuppliers(db, File.ReadAllText("../../../Datasets/suppliers.xml"));
            //ImportParts(db, File.ReadAllText("../../../Datasets/parts.xml"));
            //ImportCars(db, File.ReadAllText("../../../Datasets/cars.xml"));
            //ImportCustomers(db, File.ReadAllText("../../../Datasets/customers.xml"));
            //ImportSales(db, File.ReadAllText("../../../Datasets/sales.xml"));

            var result = GetSalesWithAppliedDiscount(db);
            File.WriteAllText("../../../Datasets/Results/sales-discounts.xml", result);
        }

        //Query 9.Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var rootElement = "Suppliers";

            var suppliers = XmlConverter.Deserializer<ImportSuppliersDTO>(inputXml, rootElement)
                .Select(s => new Supplier()
                {
                    Name = s.Name,
                    IsImporter = s.IsImporter
                })
                .ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        //Query 10.Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var rootElement = "Parts";

            var parts = XmlConverter.Deserializer<ImportPartDTO>(inputXml, rootElement)
                .Where(p => context.Suppliers.Select(s => s.Id).Contains(p.SupplierId))
                .Select(p => new Part()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierId = p.SupplierId
                }).ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        //Query 11.Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var rootElement = "Cars";

            var carsDtos = XmlConverter.Deserializer<ImportCarDTO>(inputXml, rootElement);

            var cars = new List<Car>();

            foreach (var car in carsDtos)
            {
                var partsIds = car.Parts
                    .Select(p => p.Id)
                    .Distinct()
                    .Where(id => context.Parts.Any(p => p.Id == id))
                    .ToArray();

                var currCar = new Car()
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance,
                    PartCars = partsIds.Select(id => new PartCar()
                    {
                        PartId = id
                    })
                    .ToArray()
                };

                cars.Add(currCar);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        //Query 12.Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var rootElement = "Customers";

            var customers = XmlConverter.Deserializer<ImportCustomerDTO>(inputXml, rootElement)
                .Select(c => new Customer()
                {
                    Name = c.Name,
                    IsYoungDriver = c.IsYoungDriver,
                    BirthDate = DateTime.Parse(c.BirthDate)
                })
                .ToList();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        //Query 13.Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var rootElement = "Sales";

            var sales = XmlConverter.Deserializer<ImportSaleDTO>(inputXml, rootElement)
                .Where(s => context.Cars.Any(c => c.Id == s.CarId))
                .Select(s => new Sale()
                {
                    CarId = s.CarId,
                    CustomerId = s.CustomerId,
                    Discount = s.Discount
                })
                .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        //Query 14.Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var rootElement = "cars";

            var carsWithDistance = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .Select(c => new ExportCarWithDistanceDTO()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();

            return XmlConverter.Serialize(carsWithDistance, rootElement);
        }

        //Query 15.Cars from make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var rootElement = "cars";

            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new ExportCarFromMakeDTO()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();

            return XmlConverter.Serialize(cars, rootElement);
        }

        //Query 16.Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var rootElement = "suppliers";

            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new ExportLocaleSuplierDTO()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            return XmlConverter.Serialize(suppliers, rootElement);
        }

        //Query 17.Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var rootElement = "cars";

            var carsWithParts = context.Cars
                .Select(c => new ExportCarWithPartsDTO()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars.Select(p => new PartDTO()
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToList();

            return XmlConverter.Serialize(carsWithParts, rootElement);
        }

        //Query 18.Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var rootElement = "customers";

            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new ExportCustomerDTO()
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentModey = c.Sales.Sum(s => s.Car.PartCars.Sum(p => p.Part.Price))
                })
                .OrderByDescending(c => c.SpentModey)
                .ToList();

            return XmlConverter.Serialize(customers, rootElement);
        }

        //Query 19.Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var rootElement = "sales";

            var sales = context.Sales
                .Select(s => new ExportSaleInfoDTO()
                {
                    Car = new ExportCarInfoDTO()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount = s.Car.PartCars.Sum(pc => pc.Part.Price) - s.Car.PartCars.Sum(pc => pc.Part.Price) * s.Discount / 100
                })
                .ToList();

            return XmlConverter.Serialize(sales, rootElement);
        }
    }
}