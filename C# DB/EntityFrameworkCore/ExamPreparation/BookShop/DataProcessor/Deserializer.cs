namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportBookDTO[]), new XmlRootAttribute("Books"));

            var result = new StringBuilder();

            using (var reader = new StringReader(xmlString))
            {
                var booksDtos = (ImportBookDTO[])xmlSerializer.Deserialize(reader);

                var books = new List<Book>();

                foreach (var bookDto in booksDtos)
                {
                    if (!IsValid(bookDto))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime publishedOn;

                    var isDateValid = DateTime.TryParseExact(bookDto.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out publishedOn);

                    if (!isDateValid)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var currentBook = new Book()
                    {
                        Name = bookDto.Name,
                        Genre = (Genre)bookDto.Genre,
                        Price = bookDto.Price,
                        Pages = bookDto.Pages,
                        PublishedOn = publishedOn
                    };

                    books.Add(currentBook);
                    result.AppendLine(string.Format(SuccessfullyImportedBook, currentBook.Name, currentBook.Price));
                }

                context.Books.AddRange(books);
                context.SaveChanges();

                return result.ToString().TrimEnd();
            }
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var authorsDtos = JsonConvert.DeserializeObject<ImportAuthorDTO[]>(jsonString);

            var authors = new List<Author>();

            var result = new StringBuilder();

            foreach (var authorDto in authorsDtos)
            {
                if (!IsValid(authorDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                if (authors.Any(a => a.Email == authorDto.Email))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var currentAuthor = new Author()
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    Email = authorDto.Email,
                    Phone = authorDto.Phone
                };

                foreach (var bookDto in authorDto.Books)
                {
                    var book = context.Books
                        .FirstOrDefault(b => b.Id == bookDto.BookId);

                    if (book == null)
                    {
                        continue;
                    }

                    currentAuthor.AuthorsBooks.Add(new AuthorBook
                    {
                        Author = currentAuthor,
                        Book = book
                    });
                }

                if (currentAuthor.AuthorsBooks.Count == 0)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                authors.Add(currentAuthor);
                result.AppendLine(string.Format(SuccessfullyImportedAuthor, currentAuthor.FirstName + " " + currentAuthor.LastName, currentAuthor.AuthorsBooks.Count));
            }

            context.Authors.AddRange(authors);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}