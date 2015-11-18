namespace AdultMovies
{
    using Movies.Data;
    using Movies.Models;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;

    class AdultMovies
    {
        static void Main()
        {
            var context = new MoviesContext();
            var movies = context.Movies
                .Where(m => m.AgeRestriction == AgeRestriction.Adult)
                .OrderBy(m => m.Title)
                .ThenByDescending(m => m.Ratings.Count)
                .Select(m => new
                {
                    title = m.Title,
                    ratingsGiven = m.Ratings.Count
                });

            string json = JsonConvert.SerializeObject(movies, Formatting.Indented);
            File.WriteAllText("../../adult-movies.json", json);
        }
    }
}
