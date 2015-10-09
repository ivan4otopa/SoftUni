namespace Twitter.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class User : IdentityUser
    {
        private ICollection<User> followers;
        private ICollection<User> following;
        private ICollection<Tweet> tweets;
        private ICollection<Message> sentMessages;
        private ICollection<Message> receivedMessages;
        private ICollection<Tweet> favouriteTweets;
        private ICollection<Notification> notifications;
        private ICollection<Report> reports;

        public User()
        {
            this.Followers = new HashSet<User>();
            this.Following = new HashSet<User>();
            this.Tweets = new HashSet<Tweet>();
            this.SentMessages = new HashSet<Message>();
            this.ReceivedMessages = new HashSet<Message>();
            this.FavouriteTweets = new HashSet<Tweet>();
            this.Notifications = new HashSet<Notification>();
            this.Reports = new HashSet<Report>();
        }

        public int ProfileId { get; set; }

        public virtual Profile Profile { get; set; }

        public virtual ICollection<User> Followers
        {
            get
            {
                return this.followers;
            }

            set
            {
                this.followers = value;
            }
        }

        public virtual ICollection<User> Following
        {
            get
            {
                return this.following;
            }

            set
            {
                this.following = value;
            }
        }

        public virtual ICollection<Tweet> Tweets
        {
            get
            {
                return this.tweets;
            }

            set
            {
                this.tweets = value;
            }
        }

        [InverseProperty("Sender")]
        public virtual ICollection<Message> SentMessages
        {
            get
            {
                return this.sentMessages;
            }

            set
            {
                this.sentMessages = value;
            }
        }

        [InverseProperty("Receiver")]
        public virtual ICollection<Message> ReceivedMessages
        {
            get
            {
                return this.receivedMessages;
            }

            set
            {
                this.receivedMessages = value;
            }
        }

        public virtual ICollection<Tweet> FavouriteTweets
        {
            get
            {
                return this.favouriteTweets;
            }

            set
            {
                this.favouriteTweets = value;
            }
        }

        public virtual ICollection<Notification> Notifications
        {
            get
            {
                return this.notifications;
            }

            set
            {
                this.notifications = value;
            }
        }

        public virtual ICollection<Report> Reports
        {
            get
            {
                return this.reports;
            }

            set
            {
                this.reports = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }
    }
}
