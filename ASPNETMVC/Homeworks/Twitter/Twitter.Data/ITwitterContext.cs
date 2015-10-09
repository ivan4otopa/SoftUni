namespace Twitter.Data
{
    using System.Data.Entity;
    using Models;

    public interface ITwitterContext
    {
        IDbSet<Tweet> Tweets { get; set; }

        IDbSet<Profile> Profiles { get; set; }

        IDbSet<Message> Messages { get; set; }

        IDbSet<Report> Reports { get; set; }

        IDbSet<Notification> Notifications { get; set; }
    }
}
