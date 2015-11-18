namespace Movies.Data.Migrations
{
    using Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;

    internal sealed class Configuration : DbMigrationsConfiguration<Movies.Data.MoviesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Movies.Data.MoviesContext";
        }

        protected override void Seed(Movies.Data.MoviesContext context)
        {
            if (context.Countries.Any())
            {
                return;
            }

            var serializer = new JavaScriptSerializer();
            var countriesFile = File.ReadAllText("../../countries.json");
            var countries = serializer.Deserialize<List<Country>>(countriesFile);

            foreach (var country in countries)
            {
                context.Countries.Add(new Country()
                {
                    Name = country.Name
                });
            }

            context.SaveChanges();

            var usersFile = File.ReadAllText("../../users.json");
            var users = JsonConvert.DeserializeObject<List<JObject>>(usersFile);

            foreach (var user in users)
            {
                string username = (string)user["username"];
                int? age = user["age"] == null ? null : (int?)user["age"];
                string email = user["email"] == null ? null : (string)user["email"];
                string country = user["country"] == null ? null : (string)user["country"];

                if (country != null)
                {
                    context.Users.Add(new User()
                    {
                        Username = username,
                        Age = age,
                        Email = email,
                        CountryId = context.Countries.Where(c => c.Name == country).FirstOrDefault().Id
                    });
                }
                else
                {
                    context.Users.Add(new User()
                    {
                        Username = username,
                        Age = age,
                        Email = email,
                        CountryId = null
                    });
                }
            }

            context.SaveChanges();

            var moviesFile = File.ReadAllText("../../movies.json");
            var movies = serializer.Deserialize<List<Movie>>(moviesFile);

            foreach (var movie in movies)
            {
                context.Movies.Add(new Movie()
                {
                    Isbn = movie.Isbn,
                    Title = movie.Title,
                    AgeRestriction = movie.AgeRestriction
                });
            }

            context.SaveChanges();

            var usersMoviesFile = File.ReadAllText("../../users-and-favourite-movies.json");
            dynamic usersMovies = JsonConvert.DeserializeObject(usersMoviesFile);

            foreach (var userMovie in usersMovies)
            {
                string username = userMovie.username;
                var currentUser = context.Users.Where(u => u.Username == username).FirstOrDefault();

                foreach (var movie in userMovie.favouriteMovies)
                {
                    string isbn = movie;
                    var currentMovie = context.Movies.Where(m => m.Isbn == isbn).FirstOrDefault();

                    currentUser.Movies.Add(currentMovie);
                }
            }

            context.SaveChanges();

            var moviesRatingsFile = File.ReadAllText("../../movie-ratings.json");
            dynamic moviesRatings = JsonConvert.DeserializeObject(moviesRatingsFile);

            foreach (var movieRating in moviesRatings)
            {
                string user = movieRating.user;
                string movie = movieRating.movie;
                var userId = context.Users.Where(u => u.Username == user).FirstOrDefault().Id;
                var movieId = context.Movies.Where(m => m.Isbn == movie).FirstOrDefault().Id;

                context.Ratings.Add(new Rating()
                {
                    Stars = movieRating.rating,
                    UserId = userId,
                    MovieId = movieId
                });
            }

            context.SaveChanges();
        }
    }
}
