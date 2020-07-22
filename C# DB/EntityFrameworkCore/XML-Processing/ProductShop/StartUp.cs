using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using ProductShop.XmlHelper;
using System;
using System.IO;
using System.Linq;
using System.Xml.Schema;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();

            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            var resultXml = GetUsersWithProducts(db);

            File.WriteAllText("../../../Datasets/Results/users-and-products.xml", resultXml);
        }

        //Query 1.Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var rootElement = "Users";

            var users = XmlConverter.Deserializer<ImportUserDTO>(inputXml, rootElement)
                .Select(u => new User
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age
                })
                .ToList();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //Query 2.Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var rootElement = "Products";

            var products = XmlConverter.Deserializer<ImportProductDTO>(inputXml, rootElement)
                .Select(p => new Product
                {
                    Name = p.Name,
                    Price = p.Price,
                    SellerId = p.SellerId,
                    BuyerId = p.BuyerId
                })
                .ToList();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //Query 3.Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var rootElement = "Categories";

            var categories = XmlConverter.Deserializer<ImportCategoryDTO>(inputXml, rootElement)
                .Select(c => new Category()
                {
                    Name = c.Name
                })
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //Query 4.Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var rootElement = "CategoryProducts";

            var categoryProducts = XmlConverter.Deserializer<ImportCategoryProductDTO>(inputXml, rootElement)
                .Where(cp => context.Categories.Any(c => c.Id == cp.CategoryId) &&
                             context.Products.Any(p => p.Id == cp.ProductId))
                .Select(cp => new CategoryProduct()
                {
                    CategoryId = cp.CategoryId,
                    ProductId = cp.ProductId
                })
                .ToList();

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //Query 5.Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var rootElement = "Products";

            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(p => new ExportProductInfoDTO()
                {
                    Name = p.Name,
                    Price = p.Price,
                    BuyerFullName = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .ToList();

            return XmlConverter.Serialize(products, rootElement);
        }

        //Query 6.Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var rootElement = "Users";

            var soldProducts = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new ExportUsersWithSoldProductsDTO()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(p => new UserSoldProductDTO()
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToArray()
                })
                .ToList();

            return XmlConverter.Serialize(soldProducts, rootElement);
        }

        //Query 7.Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var rootElement = "Categories";

            var categories = context.Categories
                .Select(c => new ExportCategoryByProductsDTO()
                {
                    Name = c.Name,
                    CountOfProducts = c.CategoryProducts.Count,
                    AvgPrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.CountOfProducts)
                .ThenBy(c=>c.TotalRevenue)
                .ToList();

            return XmlConverter.Serialize(categories, rootElement);
        }

        //Query 8.Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var rootElement = "Users";

            var usersAndProducts = context.Users
                .Where(u => u.ProductsSold.Any())
                //.AsEnumerable() //for judge system
                .Select(u => new ExportUserInfoDTO()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExportProductCountDTO()
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold.Select(p => new ExportProductDTO()
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .Take(10)
                .ToArray();

            var result = new ExportUserCountDTO()
            {
                Count = context.Users.Where(u => u.ProductsSold.Any()).Count(),
                Users = usersAndProducts
            };

            return XmlConverter.Serialize(result, rootElement);
        }
    }
}