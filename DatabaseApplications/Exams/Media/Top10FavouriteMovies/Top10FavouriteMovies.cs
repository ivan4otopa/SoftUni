namespace Top10FavouriteMovies
{
    using System.IO;
    using System.Linq;

    using Movies.Data;
    using Movies.Models;

    using Newtonsoft.Json;

    class Top10FavouriteMovies
    {
        static void Main()
        {
            var context = new MoviesContext();
            var movies = context.Movies
                .Where(m => m.AgeRestriction == AgeRestriction.Teen)
                .OrderByDescending(m => m.Users.Count)
                .ThenBy(m => m.Title)
                .Select(m => new
                {
                    isbn = m.Isbn,
                    title = m.Title,
                    favouritedBy = m.Users
                        .Select(u => u.Username)
                })
                .Take(10);

            string json = JsonConvert.SerializeObject(movies, Formatting.Indented);
            File.WriteAllText("../../top-10-favourite-movies.json", json);
        }
    }
}
