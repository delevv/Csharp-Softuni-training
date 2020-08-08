namespace VaporStore.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genres = context.Genres
                .Where(g => genreNames.Contains(g.Name))
                .AsEnumerable()
                .Select(g => new
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games
                                .Where(ga => ga.Purchases.Any())
                                .Select(ga => new
                                {
                                    Id = ga.Id,
                                    Title = ga.Name,
                                    Developer = ga.Developer.Name,
                                    Tags = string.Join(", ", ga.GameTags.Select(gt => gt.Tag.Name)),
                                    Players = ga.Purchases.Count
                                })
                                .OrderByDescending(ga => ga.Players)
                                .ThenBy(ga => ga.Id),
                    TotalPlayers = g.Games.Sum(ga => ga.Purchases.Count)
                })
                .OrderByDescending(g => g.TotalPlayers)
                .ThenBy(g => g.Id)
                .ToArray();

            return JsonConvert.SerializeObject(genres, Formatting.Indented);
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var users = context.Users
                .AsEnumerable()
                .Where(u => u.Cards.Any(c => c.Purchases.Any(p => p.Type.ToString() == storeType)))
                .Select(u => new ExportUserDTO()
                {
                    Username = u.Username,
                    Purchases = u.Cards.SelectMany(c => c.Purchases.Where(p => p.Type.ToString() == storeType))
                        .Select(p => new ExportPurchaseDTO()
                        {
                            CardNumber = p.Card.Number,
                            Cvc = p.Card.Cvc,
                            Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new ExportGameDTO()
                            {
                                GameName = p.Game.Name,
                                Genre = p.Game.Genre.Name,
                                Price = p.Game.Price
                            }
                        })
                        .OrderBy(p => p.Date)
                        .ToArray(),
                    TotalSpent = u.Cards
                                    .Sum(c => c.Purchases
                                        .Where(p => p.Type.ToString() == storeType)
                                        .Sum(p => p.Game.Price))
                })
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToArray();

            var result = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(ExportUserDTO[]), new XmlRootAttribute("Users"));
            var xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            using (var writter = new StringWriter(result))
            {
                xmlSerializer.Serialize(writter, users, xmlNamespaces);
            }

            return result.ToString().TrimEnd();
        }
    }
}