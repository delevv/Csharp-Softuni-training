namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Castle.Core.Internal;
    using Data;
    using Microsoft.EntityFrameworkCore.Internal;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var writersDtos = JsonConvert.DeserializeObject<ImportWriterDTO[]>(jsonString);

            var writers = new List<Writer>();

            var result = new StringBuilder();

            foreach (var writerDto in writersDtos)
            {
                if (!IsValid(writerDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var currentWriter = new Writer()
                {
                    Name = writerDto.Name,
                    Pseudonym = writerDto.Pseudonym
                };

                result.AppendLine(string.Format(SuccessfullyImportedWriter, currentWriter.Name));
                writers.Add(currentWriter);
            }

            context.Writers.AddRange(writers);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producersDtos = JsonConvert.DeserializeObject<ImportProducerDTO[]>(jsonString);

            var producers = new List<Producer>();

            var result = new StringBuilder();

            foreach (var producerDto in producersDtos)
            {
                if (!IsValid(producerDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var isAlbumsCorrect = true;

                var currentProducer = new Producer()
                {
                    Name = producerDto.Name,
                    PhoneNumber = producerDto.PhoneNumber,
                    Pseudonym = producerDto.Pseudonym,
                    Albums = new HashSet<Album>()
                };

                foreach (var albumDto in producerDto.Albums)
                {
                    if (!IsValid(albumDto))
                    {
                        result.AppendLine(ErrorMessage);
                        isAlbumsCorrect = false;
                        break;
                    }

                    var releaseDate = DateTime.ParseExact(albumDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    currentProducer.Albums.Add(new Album()
                    {
                        Name = albumDto.Name,
                        Producer = currentProducer,
                        ReleaseDate = releaseDate
                    });
                }

                if (isAlbumsCorrect)
                {
                    producers.Add(currentProducer);

                    if (!currentProducer.PhoneNumber.IsNullOrEmpty())
                    {
                        result.AppendLine(string.Format(SuccessfullyImportedProducerWithPhone, currentProducer.Name, currentProducer.PhoneNumber, currentProducer.Albums.Count));
                    }
                    else
                    {
                        result.AppendLine(string.Format(SuccessfullyImportedProducerWithNoPhone, currentProducer.Name, currentProducer.Albums.Count));
                    }
                }
            }

            context.Producers.AddRange(producers);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSongDTO[]), new XmlRootAttribute("Songs"));

            var result = new StringBuilder();

            using (var reader = new StringReader(xmlString))
            {
                var songsDtos = (ImportSongDTO[])xmlSerializer.Deserialize(reader);

                var songs = new List<Song>();

                foreach (var songDto in songsDtos)
                {
                    if (!IsValid(songDto))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    Album album = null;

                    if (songDto.AlbumId.HasValue)
                    {
                        album = context.Albums
                            .FirstOrDefault(a => a.Id == songDto.AlbumId);
                    }

                    var writer = context.Writers
                        .FirstOrDefault(w => w.Id == songDto.WriterId);

                    if (album == null || writer == null)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var createdOn = DateTime.ParseExact(songDto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    var duration = TimeSpan.ParseExact(songDto.Duration, "c", CultureInfo.InvariantCulture);

                    Genre genre;

                    var isEnumValid = Enum.TryParse(songDto.Genre, out genre);

                    if (!isEnumValid)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var song = new Song()
                    {
                        Name = songDto.Name,
                        Genre = (Genre)Enum.Parse(typeof(Genre), songDto.Genre, true),
                        CreatedOn = createdOn,
                        Duration = duration,
                        Price = songDto.Price,
                        Album = album,
                        Writer = writer
                    };

                    songs.Add(song);

                    result.AppendLine(string.Format(SuccessfullyImportedSong, song.Name, song.Genre, song.Duration));
                }

                context.Songs.AddRange(songs);
                context.SaveChanges();

                return result.ToString().TrimEnd();
            }
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPerformerDTO[]), new XmlRootAttribute("Performers"));

            var result = new StringBuilder();

            using (var reader = new StringReader(xmlString))
            {
                var performersDtos = (ImportPerformerDTO[])xmlSerializer.Deserialize(reader);

                var performers = new List<Performer>();

                foreach (var performerDto in performersDtos)
                {
                    if (!IsValid(performerDto))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var currentPerformer = new Performer()
                    {
                        FirstName = performerDto.FirstName,
                        LastName = performerDto.LastName,
                        Age = performerDto.Age,
                        NetWorth = performerDto.NetWorth
                    };

                    var isSongsValid = true;

                    foreach (var songDto in performerDto.PerformerSongs)
                    {
                        var song = context.Songs
                            .FirstOrDefault(s => s.Id == songDto.Id);

                        if (song == null)
                        {
                            result.AppendLine(ErrorMessage);
                            isSongsValid = false;
                            break;
                        }

                        currentPerformer.PerformerSongs.Add(new SongPerformer()
                        {
                            Song = song,
                            Performer = currentPerformer
                        });
                    }

                    if (isSongsValid)
                    {
                        performers.Add(currentPerformer);

                        result.AppendLine(string.Format(SuccessfullyImportedPerformer, currentPerformer.FirstName, currentPerformer.PerformerSongs.Count));
                    }
                }

                context.Performers.AddRange(performers);
                context.SaveChanges();

                return result.ToString().TrimEnd();
            }
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}