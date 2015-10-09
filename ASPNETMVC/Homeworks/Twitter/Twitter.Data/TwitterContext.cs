namespace Twitter.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Migrations;

    public class TwitterContext : IdentityDbContext<User>, ITwitterContext
    {
        public TwitterContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TwitterContext, Configuration>());   
        }

        public virtual IDbSet<Tweet> Tweets { get; set; }

        public virtual IDbSet<Profile> Profiles { get; set; }

        public virtual IDbSet<Message> Messages { get; set; }

        public virtual IDbSet<Report> Reports { get; set; }

        public virtual IDbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasRequired(m => m.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.SenderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .HasRequired(m => m.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverId)
                .WillCascadeOnDelete(false);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Followers)
                .WithMany()
                .Map(x =>
                {
                    x.MapLeftKey("UserId");
                    x.MapRightKey("FollowerId");
                    x.ToTable("UsersFollowers");
                });

            modelBuilder.Entity<User>()
                .HasMany(u => u.Following)
                .WithMany()
                .Map(x =>
                {
                    x.MapLeftKey("UserId");
                    x.MapRightKey("FollowingId");
                    x.ToTable("UsersFollowings");
                });

            modelBuilder.Entity<User>()
                .HasMany(u => u.FavouriteTweets)
                .WithMany(t => t.UsersWhoFavourited)
                .Map(x =>
                {
                    x.MapLeftKey("UserId");
                    x.MapRightKey("TweetId");
                    x.ToTable("UsersFavouriteTweets");
                });

            base.OnModelCreating(modelBuilder);
        }

        public static TwitterContext Create()
        {
            return new TwitterContext();
        }
    }
}