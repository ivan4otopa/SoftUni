namespace News.Data.Repositories
{
    using System.Linq;
    using Models;
    using System.Data.Entity;

    public class NewsRepository : IRepository<NewsModel>
    {
        private readonly DbContext context;

        public NewsRepository(DbContext context)
        {
            this.context = context;
        }

        public NewsModel Add(NewsModel entity)
        {
            this.context.Set<NewsModel>().Add(entity);

            return entity;
        }

        public IQueryable<NewsModel> All()
        {
            return this.context.Set<NewsModel>()
                .OrderByDescending(n => n.PublishDate);
        }

        public void Delete(int id)
        {
            var news = this.Find(id);

            this.context.Set<NewsModel>().Remove(news);
        }

        public NewsModel Find(int id)
        {
            return this.context.Set<NewsModel>().Find(id);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public void Update(int id, NewsModel entity)
        {
            var news = this.Find(id);

            news.Title = entity.Title;
            news.Content = entity.Content;
            news.PublishDate = entity.PublishDate;
        }
    }
}
