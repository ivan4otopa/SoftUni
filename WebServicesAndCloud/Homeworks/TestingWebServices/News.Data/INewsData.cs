namespace News.Data
{
    using Repositories;
    using Models;

    public interface INewsData
    {
        IGenericRepository<NewsModel> News { get; }

        int SaveChanges();
    }
}
