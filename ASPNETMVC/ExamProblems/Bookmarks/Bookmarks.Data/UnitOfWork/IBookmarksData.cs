namespace Bookmarks.Data.UnitOfWork
{
    using Repositories;
    using Models;

    public interface IBookmarksData
    {
        IRepository<Bookmark> Bookmarks { get; }

        IRepository<Category> Categories { get; }

        IRepository<Vote> Votes { get; }

        IRepository<User> Users { get; }

        IRepository<Comment> Comments { get; }

        void SaveChanges();
    }
}
