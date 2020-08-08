namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Microsoft.EntityFrameworkCore.Internal;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var gamesDtos = JsonConvert.DeserializeObject<ImportGameDTO[]>(jsonString);

            var games = new List<Game>();

            var developers = new List<Developer>();
            var tags = new List<Tag>();
            var genres = new List<Genre>();

            var result = new StringBuilder();

            foreach (var gameDto in gamesDtos)
            {
                if (!IsValid(gameDto))
                {
                    result.AppendLine("Invalid Data");
                    continue;
                }

                DateTime releaseDate;

                var isReleaseDateValid = DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate);

                if (!isReleaseDateValid)
                {
                    result.AppendLine("Invalid Data");
                    continue;
                }

                var game = new Game()
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = releaseDate
                };

                var developer = developers.FirstOrDefault(d => d.Name == gameDto.Developer);

                if (developer == null)
                {
                    developer = new Developer()
                    {
                        Name = gameDto.Developer
                    };
                    developers.Add(developer);
                }

                developer.Games.Add(game);
                game.Developer = developer;

                var genre = genres.FirstOrDefault(g => g.Name == gameDto.Genre);

                if (genre == null)
                {
                    genre = new Genre()
                    {
                        Name = gameDto.Genre
                    };
                    genres.Add(genre);
                }

                genre.Games.Add(game);
                game.Genre = genre;

                if (!gameDto.Tags.Any())
                {
                    result.AppendLine("Invalid Data");
                    continue;
                }

                foreach (var tag in gameDto.Tags)
                {
                    var currentTag = tags.FirstOrDefault(t => t.Name == tag);

                    if (currentTag == null)
                    {
                        currentTag = new Tag()
                        {
                            Name = tag
                        };

                        tags.Add(currentTag);
                    }

                    var gameTag = new GameTag()
                    {
                        Game = game,
                        Tag = currentTag
                    };

                    game.GameTags.Add(gameTag);
                }

                games.Add(game);
                result.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var usersDtos = JsonConvert.DeserializeObject<ImportUserDTO[]>(jsonString);

            var users = new List<User>();

            var result = new StringBuilder();

            foreach (var userDto in usersDtos)
            {
                if (!IsValid(userDto))
                {
                    result.AppendLine("Invalid Data");
                    continue;
                }

                if (!userDto.Cards.Any())
                {
                    result.AppendLine("Invalid Data");
                    continue;
                }

                var currentUser = new User()
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Age = userDto.Age,
                    Email = userDto.Email
                };

                var isCardsValid = true;

                var cards = new List<Card>();

                foreach (var cardDto in userDto.Cards)
                {
                    if (!IsValid(cardDto))
                    {
                        result.AppendLine("Invalid Data");
                        isCardsValid = false;
                        break;
                    }

                    CardType type;

                    var isEnumValid = Enum.TryParse(cardDto.Type, out type);

                    if (!isEnumValid)
                    {
                        result.AppendLine("Invalid Data");
                        isCardsValid = false;
                        break;
                    }

                    cards.Add(new Card()
                    {
                        Number = cardDto.Number,
                        Type = type,
                        Cvc = cardDto.Cvc,
                        User = currentUser
                    });
                }

                currentUser.Cards = cards;

                if (isCardsValid)
                {
                    users.Add(currentUser);
                    result.AppendLine($"Imported {currentUser.Username} with {currentUser.Cards.Count} cards");
                }
            }

            context.AddRange(users);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPurchaseDTO[]), new XmlRootAttribute("Purchases"));

            var result = new StringBuilder();

            using (var reader = new StringReader(xmlString))
            {
                var purchasesDtos = (ImportPurchaseDTO[])xmlSerializer.Deserialize(reader);

                var purchases = new List<Purchase>();

                foreach (var purchaseDto in purchasesDtos)
                {
                    if (!IsValid(purchaseDto))
                    {
                        result.AppendLine("Invalid Data");
                        continue;
                    }

                    PurchaseType type;

                    var isEnumValid = Enum.TryParse(purchaseDto.Type, out type);

                    if (!isEnumValid)
                    {
                        result.AppendLine("Invalid Data");
                        continue;
                    }

                    DateTime date;

                    var isDateValid = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

                    if (!isDateValid)
                    {
                        result.AppendLine("Invalid Data");
                        continue;
                    }

                    var game = context.Games.FirstOrDefault(g => g.Name == purchaseDto.GameName);
                    var card = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.CardNumber);

                    if (game == null || card == null)
                    {
                        result.AppendLine("Invalid Data");
                        continue;
                    }

                    var currentPurchase = new Purchase()
                    {
                        Game = game,
                        Card = card,
                        Date = date,
                        Type = type,
                        ProductKey = purchaseDto.ProductKey
                    };

                    purchases.Add(currentPurchase);

                    result.AppendLine($"Imported {currentPurchase.Game.Name} for {currentPurchase.Card.User.Username}");
                }

                context.Purchases.AddRange(purchases);
                context.SaveChanges();
            }

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