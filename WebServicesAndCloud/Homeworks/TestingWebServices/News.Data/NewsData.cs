namespace News.Data
{
    using System;
    using Repositories;
    using Models;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class NewsData : INewsData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public NewsData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }        
        public IGenericRepository<NewsModel> News
        {
            get { return this.GetRepository<NewsModel>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);
                var repository = Activator.CreateInstance(
                typeOfRepository, this.context);
                this.repositories.Add(type, repository);
            }
            return (IGenericRepository<T>)this.repositories[type];
        }
    }
}
