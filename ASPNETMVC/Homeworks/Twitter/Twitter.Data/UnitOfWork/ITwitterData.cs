namespace Twitter.Data.UnitOfWork
{
    using Repositories;
    using Models;

    public interface ITwitterData
    {
        IRepository<User> Users { get; }

        IRepository<Tweet> Tweets { get; }

        IRepository<Profile> Profiles { get; }

        IRepository<Notification> Notifications { get; }

        IRepository<Message> Messages { get; }

        IRepository<Report> Reports { get; }

        void SaveChanges();
    }
}
