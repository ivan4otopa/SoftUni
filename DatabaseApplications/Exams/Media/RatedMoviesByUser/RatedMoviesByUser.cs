namespace RatedMoviesByUser
{
    using System.IO;
    using System.Linq;

    using Movies.Data;

    using Newtonsoft.Json;

    class RatedMoviesByUser
    {
        static void Main()
        {
            var context = new MoviesContext();
            var user = context.Users
                .Where(u => u.Username == "jmeyery")
                .Select(u => new
                {
                    username = u.Username,
                    ratedMovies = u.Ratings
                        .OrderBy(r => r.Movie.Title)
                        .Select(r => new
                        {
                            title = r.Movie.Title,
                            userRating = r.Stars,
                            averageRating = r.Movie.Ratings.Average(mr => mr.Stars)
                        })
                });

            string json = JsonConvert.SerializeObject(user, Formatting.Indented);
            File.WriteAllText("../../rated-movies-by-jmeyery.json", json);
        }
    }
}
