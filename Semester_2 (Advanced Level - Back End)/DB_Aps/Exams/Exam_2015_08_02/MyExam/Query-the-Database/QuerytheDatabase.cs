namespace Query_the_Database
{
    using System;
    using System.IO;
    using System.Linq;
    using Code_First;
    using Code_First.Model;
    using Newtonsoft.Json;

    class QuerytheDatabase
    {
        static void Main()
        {
            var context = new MoviesContext();

            ////1.AdultMovies
            ExportAdultMoviesToJSON(context);

            ////2.Rated Movies by User
            ExportRatedMoviesByUser(context);

            //3. Top 10 Favourite Movies
            ExportTop10Movies(context);


        }

        private static void ExportTop10Movies(MoviesContext context)
        {
            var mostFavourite = context.Movies
                .OrderByDescending(m => m.Users.Count)
                .Take(10)
                .Select(m => new
                {
                    isbn = m.Isbn,
                    title = m.Title,
                    favouriteBy = m.Users
                        .Select(u => u.UserName)
                }).OrderByDescending(f => f.favouriteBy.Count())
                .ThenBy(f => f.title).ToList();

            var beautifulJson = JsonConvert.SerializeObject(mostFavourite, Formatting.Indented);
            File.WriteAllText(@"../../../Exports/top-10-favourite-movies.json", beautifulJson);
        }

        private static void ExportRatedMoviesByUser(MoviesContext context)
        {
            var ratedMovies = context.Users
                .Select(u => new
                {
                    username = u.UserName,
                    ratedMovies = u.Movies
                        .OrderBy(m => m.Title)
                        .Select(m => new
                        {
                            title = m.Title,
                            userRating = m.Ratingses.Count,
                            averageRating = m.Ratingses.Average(a => a.Stars)
                        })
                }).ToList();

            var beautifulJson = JsonConvert.SerializeObject(ratedMovies);
            File.WriteAllText(@"../../../Exports/rated-movies-by-jmeyery.json", beautifulJson);
        }

        private static void ExportAdultMoviesToJSON(MoviesContext context)
        {
            var adultMovies = context.Movies
                .Where(m => m.AgeRestriction == AgeRestriction.Adult)
                .OrderBy(m => m.Title)
                .ThenBy(m => m.Ratingses.Count)
                .Select(m => new
                {
                    title = m.Title,
                    ratingsGiven = m.Ratingses.Count
                }).ToList();

            var beautifulJson = JsonConvert.SerializeObject(adultMovies);
            File.WriteAllText(@"../../../Exports/adult-movies.json", beautifulJson);
        }
    }
}
