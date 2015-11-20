namespace Bookmarks.Data.UnitOfWork
{
    using Repositories;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Models;

    public class BookmarksData : IBookmarksData
    {
        private readonly DbContext dbContext;
        private readonly IDictionary<Type, object> repositories;

        public BookmarksData()
            : this(new BookmarksContext())
        {
        }

        public BookmarksData(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Bookmark> Bookmarks
        {
            get { return this.GetRepository<Bookmark>(); }
        }

        public IRepository<Category> Categories
        {
            get { return this.GetRepository<Category>(); }
        }

        public IRepository<Vote> Votes
        {
            get { return this.GetRepository<Vote>(); }
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T),
                    Activator.CreateInstance(type, this.dbContext));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
