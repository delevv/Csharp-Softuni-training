namespace MusicHub.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using MusicHub.DataProcessor.ExportDtos;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                                .Select(s => new
                                {
                                    SongName = s.Name,
                                    Price = s.Price.ToString("f2"),
                                    Writer = s.Writer.Name
                                })
                                .OrderByDescending(s => s.SongName)
                                .ThenBy(s => s.Writer)
                                .ToArray(),
                    AlbumPrice = a.Price.ToString("f2")
                })
                .OrderByDescending(a => a.AlbumPrice)
                .ToList();

            return JsonConvert.SerializeObject(albums, Formatting.Indented);
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                 .Where(s => s.Duration.Seconds > duration)
                 .ToArray()
                 .Select(s => new ExportSongDTO()
                 {
                     Name = s.Name,
                     Performer = s.SongPerformers.FirstOrDefault()
                                     .Performer
                                     .FirstName +
                                     " " +
                                     s.SongPerformers.FirstOrDefault()
                                                        .Performer
                                                        .LastName,
                     Writer = s.Writer.Name,
                     AlbumProducer = s.Album.Producer.Name,
                     Duration = s.Duration.ToString("c")
                 })
                 .OrderBy(s => s.Name)
                 .ThenBy(s => s.Writer)
                 .ThenBy(s => s.Performer)
                 .ToArray();

            var result = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(ExportSongDTO[]), new XmlRootAttribute("Songs"));
            var xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            using (var writter = new StringWriter(result))
            {
                xmlSerializer.Serialize(writter, songs, xmlNamespaces);
            }

            return result.ToString().TrimEnd();
        }
    }
}