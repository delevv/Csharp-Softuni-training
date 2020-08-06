namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var moviesDtos = JsonConvert.DeserializeObject<ImportMovieDTO[]>(jsonString);

            var movies = new List<Movie>();

            var result = new StringBuilder();

            foreach (var movieDto in moviesDtos)
            {
                if (!IsValid(movieDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Genre genre;

                var isEnumValid = Enum.TryParse(movieDto.Genre, out genre);

                if (!isEnumValid)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                TimeSpan duration;

                var isDurationValid = TimeSpan.TryParseExact(movieDto.Duration, "c", CultureInfo.InvariantCulture, out duration);

                if (!isDurationValid)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var isThereMovieWithSameTitle = context.Movies.FirstOrDefault(m => m.Title == movieDto.Title) != null
                    ? true
                    : false;

                if (isThereMovieWithSameTitle)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var currentMovie = new Movie()
                {
                    Title = movieDto.Title,
                    Genre = genre,
                    Rating = movieDto.Rating,
                    Duration = duration,
                    Director = movieDto.Director
                };

                movies.Add(currentMovie);
                result.AppendLine(string.Format(SuccessfulImportMovie, currentMovie.Title, currentMovie.Genre, currentMovie.Rating.ToString("f2")));
            }

            context.Movies.AddRange(movies);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallsDto = JsonConvert.DeserializeObject<ImportHallDTO[]>(jsonString);

            var halls = new List<Hall>();

            var result = new StringBuilder();

            foreach (var hallDto in hallsDto)
            {
                if (!IsValid(hallDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var currentHall = new Hall()
                {
                    Is3D = hallDto.Is3D,
                    Is4Dx = hallDto.Is4Dx,
                    Name = hallDto.Name
                };

                var seats = new List<Seat>();

                for (int i = 0; i < hallDto.Seats; i++)
                {
                    var currentSeat = new Seat()
                    {
                        Hall = currentHall
                    };

                    seats.Add(currentSeat);
                }
                currentHall.Seats = seats;

                halls.Add(currentHall);
                var projectionType = "";

                if (!currentHall.Is4Dx && !currentHall.Is3D)
                {
                    projectionType = "Normal";
                }
                else if (currentHall.Is4Dx && currentHall.Is3D)
                {
                    projectionType = "4Dx/3D";
                }
                else if (currentHall.Is4Dx)
                {
                    projectionType = "4Dx";
                }
                else if (currentHall.Is3D)
                {
                    projectionType = "3D";
                }


                result.AppendLine(string.Format(SuccessfulImportHallSeat, currentHall.Name, projectionType, currentHall.Seats.Count));
            }

            context.Halls.AddRange(halls);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProjectionDTO[]), new XmlRootAttribute("Projections"));

            var projections = new List<Projection>();
            var result = new StringBuilder();

            using (var reader = new StringReader(xmlString))
            {
                var projectionDtos = (ImportProjectionDTO[])xmlSerializer.Deserialize(reader);

                foreach (var projectionDto in projectionDtos)
                {
                    if (!IsValid(projectionDto))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime dateTime;

                    var isDateTimeValid = DateTime.TryParseExact(projectionDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);

                    if (!isDateTimeValid)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var movie = context.Movies.FirstOrDefault(m => m.Id == projectionDto.MovieId);
                    var hall = context.Halls.FirstOrDefault(h => h.Id == projectionDto.HallId);

                    if (movie == null || hall == null)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var currentProjection = new Projection()
                    {
                        Movie = movie,
                        Hall = hall,
                        DateTime = dateTime
                    };

                    projections.Add(currentProjection);

                    result.AppendLine(string.Format(SuccessfulImportProjection, movie.Title, currentProjection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)));
                }
            }
            context.Projections.AddRange(projections);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCustomerDTO[]), new XmlRootAttribute("Customers"));

            var customers = new List<Customer>();
            var result = new StringBuilder();

            using (var reader = new StringReader(xmlString))
            {
                var customersDtos = (ImportCustomerDTO[])xmlSerializer.Deserialize(reader);

                foreach (var customerDto in customersDtos)
                {
                    if (!IsValid(customerDto))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var currentCustomer = new Customer()
                    {
                        FirstName = customerDto.FirstName,
                        LastName = customerDto.LastName,
                        Age = customerDto.Age,
                        Balance = customerDto.Balance
                    };

                    var tickets = new List<Ticket>();

                    foreach (var ticketDto in customerDto.Tickets)
                    {
                        if (!IsValid(ticketDto))
                        {
                            result.AppendLine(ErrorMessage);
                            continue;
                        }

                        var projection = context.Projections.FirstOrDefault(p => p.Id == ticketDto.ProjectionId);

                        if (projection == null)
                        {
                            result.AppendLine(ErrorMessage);
                            continue;
                        }

                        var currentTicket = new Ticket()
                        {
                            Price = ticketDto.Price,
                            Customer = currentCustomer,
                            Projection = projection
                        };

                        tickets.Add(currentTicket);
                    }

                    currentCustomer.Tickets = tickets;
                    customers.Add(currentCustomer);

                    result.AppendLine(string.Format(SuccessfulImportCustomerTicket, currentCustomer.FirstName, currentCustomer.LastName, currentCustomer.Tickets.Count));
                }
            }

            context.Customers.AddRange(customers);
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