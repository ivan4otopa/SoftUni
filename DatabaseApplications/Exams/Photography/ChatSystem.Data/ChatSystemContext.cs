namespace ChatSystem.Data
{
    using ChatSystem.Data.Migrations;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ChatSystemContext : DbContext
    {
        public ChatSystemContext()
            : base("name=ChatSystemContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ChatSystemContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.SentMessages)
                .WithRequired()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<User>()
                .HasMany(u => u.RecievedMessages)
                .WithRequired()
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Channel> Channels { get; set; }

        public IDbSet<ChannelMessage> ChannelMessages { get; set; }

        public IDbSet<UserMessage> UserMessages { get; set; }
    }
}