using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
            var db = new CarDealerContext();
            //ResetDatabase(db);

            var json = GetOrderedCustomers(db);
            File.WriteAllText("../../../Datasets/Results/ordered-customers.json", json);
        }

        private static void ResetDatabase(CarDealerContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully DELETED!");
            db.Database.EnsureCreated();
            Console.WriteLine("Database was successfully CREATED!");
        }

        //9.Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        //10.Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var suppliersIds = context.Suppliers.Select(s => s.Id).ToList();

            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
                .Where(p => suppliersIds.Contains(p.SupplierId))
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        //11.Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<List<CarDTO>>(inputJson);

            var cars = new List<Car>();
            var carParts = new List<PartCar>();

            foreach (var carDto in carsDto)
            {
                var currCar = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                cars.Add(currCar);

                foreach (var partId in carDto.PartsId.Distinct())
                {
                    var currCarPart = new PartCar()
                    {
                        Car = currCar,
                        PartId = partId
                    };

                    carParts.Add(currCarPart);
                }
            }

            context.PartCars.AddRange(carParts);
            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported { cars.Count()}.";
        }

        //12.Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported { customers.Count()}.";
        }

        //13.Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported { sales.Count()}.";
        }

        //14.Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    c.IsYoungDriver
                })
                .ToList();

            var resultJson = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return resultJson;
        }

        //15.Export Cars from Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var carsFromMakeToyota = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .OrderByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                })
                .ToList(); ;

            var resultJson = JsonConvert.SerializeObject(carsFromMakeToyota, Formatting.Indented);

            return resultJson;
        }

        //16.Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            var resultJson = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return resultJson;
        }

        //17.Export Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    },
                    parts = c.PartCars.Select(cp => new
                    {
                        cp.Part.Name,
                        Price = cp.Part.Price.ToString("f2")
                    })
                    .ToList()
                })
                .ToList();

            var resultJson = JsonConvert.SerializeObject(carsWithParts, Formatting.Indented);

            return resultJson;
        }

        //18.Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales
                                    .Sum(s => s.Car.PartCars
                                        .Sum(pc => pc.Part.Price)/* * (1 - s.Discount / 100)*/)
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToList();

            var resultJson = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return resultJson;
        }

        //19.Export Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = s.Discount.ToString("f2"),
                    price = s.Car.PartCars
                            .Sum(cp => cp.Part.Price)
                            .ToString("f2"),
                    priceWithDiscount = (s.Car.PartCars
                                        .Sum(cp => cp.Part.Price) * (1 - s.Discount / 100))
                                        .ToString("f2")
                })
                .ToList();

            var resultJson = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return resultJson;
        }
    }
}