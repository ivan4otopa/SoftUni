namespace Bookmarks.Data
{
    using Models;
    using System.Data.Entity;

    public interface IBookmarksContext
    {
        IDbSet<Bookmark> Bookmarks { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Vote> Votes { get; set; }

        IDbSet<Comment> Comments { get; set; }
    }
}
