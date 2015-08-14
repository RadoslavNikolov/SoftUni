namespace Code_First.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Security.Policy;
    using System.Web.Script.Serialization;
    using DTO;
    using Model;
    using Newtonsoft.Json;

    internal sealed class Configuration : DbMigrationsConfiguration<Code_First.MoviesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Code_First.MoviesContext context)
        {
            ImportCoutries(context);

            ImportUsers(context);

            ImportMovies(context);

            InsertRatingses(context);
        }

        private static void InsertRatingses(MoviesContext context)
        {
            var json = File.ReadAllText(@"../../../movie-ratings.json");
            var jsSerialized = new JavaScriptSerializer();
            var parsedData = jsSerialized.Deserialize<IEnumerable<RatingDTO>>(json);

            foreach (var rating in parsedData)
            {
                var user = context.Users.Where(u => u.UserName == rating.user).FirstOrDefault();
                int userId = user.Id;

                var movie = context.Movies.Where(m => m.Isbn == rating.movie).FirstOrDefault();
                int movieId = movie.Id;

                if (context.Ratingses.Any(r => r.MovieId == movieId) && context.Ratingses.Any(r => r.UserId == userId))
                {
                    continue;
                }

                var newRating = new Rating
                {
                    Stars = rating.rating,
                    UserId = userId,
                    MovieId = movieId
                };

                context.Ratingses.Add(newRating);
                context.SaveChanges();
                //Console.WriteLine("User: {0}  /  Movie: {1}   /   Stars: {2}  imported", newRating.Users.UserName, newRating.Movie.Title, newRating.Stars);
            }
        }

        private static void AddFavouriteMoviesToUsers(MoviesContext context)
        {
            if (!context.Users.FirstOrDefault().Movies.Any())
            {
                var json = File.ReadAllText(@"../../../users-and-favourite-movies.json");
                var jsSerialized = new JavaScriptSerializer();
                var parsedData = jsSerialized.Deserialize<IEnumerable<UsersMoviesDto>>(json);

                foreach (var user in parsedData)
                {
                    if (string.IsNullOrWhiteSpace(user.Username))
                    {
                        throw new ArgumentException("UserName name is required");
                    }

                    var contextUser = context.Users.FirstOrDefault(u => u.UserName == user.Username);

                    foreach (var isbn in user.FavouriteMovies)
                    {
                        var movie = context.Movies.FirstOrDefault(m => m.Isbn == isbn);
                        contextUser.Movies.Add(movie);
                    }

                    context.SaveChanges();
                }
            }
        }

        private static void ImportMovies(MoviesContext context)
        {
            if (!context.Movies.Any())
            {
                var json = File.ReadAllText(@"../../../movies.json");
                var jsSerialized = new JavaScriptSerializer();
                var parsedData = jsSerialized.Deserialize<IEnumerable<MovieDTO>>(json);

                foreach (var movie in parsedData)
                {
                    if (string.IsNullOrWhiteSpace(movie.Isbn))
                    {
                        throw new ArgumentException("ISBN is required");
                    }

                    var newMovie = new Movie
                    {
                        Isbn = movie.Isbn,
                        Title = movie.Title,
                        AgeRestriction = (AgeRestriction) movie.AgeRestriction
                    };

                    context.Movies.Add(newMovie);
                    context.SaveChanges();
                    Console.WriteLine("MovieIsbn {0} imported", movie.Isbn);
                }

                //Fill many-to-many table  MovieUsers
                AddFavouriteMoviesToUsers(context);
            }
        }

        private static void ImportUsers(MoviesContext context)
        {
            if (!context.Users.Any())
            {
                var json = File.ReadAllText(@"../../../users.json");
                var jsSerialized = new JavaScriptSerializer();
                var parsedData = jsSerialized.Deserialize<IEnumerable<UserDTO>>(json);

                foreach (var user in parsedData)
                {
                    if (string.IsNullOrWhiteSpace(user.Username))
                    {
                        throw new ArgumentException("UserName is required");
                    }

                    var country = context.Countries.FirstOrDefault(c => c.Name == user.Country);
                    int? countryId =  country != null ? country.Id : (int?) null;

                    var newUser = new User()
                    {
                        UserName = user.Username,
                        Email = user.Email,
                        Age = user.Age,
                        CountryId = countryId
                    };

                    context.Users.Add(newUser);
                    context.SaveChanges();
                    Console.WriteLine("UserName {0} imported", user.Username);
                }
            }
        }

        private static void ImportCoutries(MoviesContext context)
        {
            if (!context.Countries.Any())
            {
                var json = File.ReadAllText(@"../../../countries.json");
                var jsSerialized = new JavaScriptSerializer();
                var parsedData = jsSerialized.Deserialize<IEnumerable<CountryDTO>>(json);

                foreach (var country in parsedData)
                {
                    if (string.IsNullOrWhiteSpace(country.Name))
                    {
                        throw new ArgumentException("Name is required");
                    }

                    var newCountry = new Country()
                    {
                        Name = country.Name
                    };

                    context.Countries.Add(newCountry);
                    context.SaveChanges();

                    Console.WriteLine("Country {0} imported", country.Name);
                }
            }
        }
    }
}
