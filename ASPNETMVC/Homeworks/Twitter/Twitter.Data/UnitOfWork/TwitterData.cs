﻿namespace Twitter.Data.UnitOfWork
{
    using Repositories;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Models;

    public class TwitterData : ITwitterData
    {
        private readonly DbContext dbContext;
        private readonly IDictionary<Type, object> repositories;

        public TwitterData()
            : this(new TwitterContext())
        {
        }

        public TwitterData(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Tweet> Tweets
        {
            get { return this.GetRepository<Tweet>(); }
        }

        public IRepository<Profile> Profiles
        {
            get { return this.GetRepository<Profile>(); }
        }

        public IRepository<Notification> Notifications
        {
            get { return this.GetRepository<Notification>(); }
        }

        public IRepository<Message> Messages
        {
            get { return this.GetRepository<Message>(); }
        }

        public IRepository<Report> Reports
        {
            get { return this.GetRepository<Report>(); }
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
