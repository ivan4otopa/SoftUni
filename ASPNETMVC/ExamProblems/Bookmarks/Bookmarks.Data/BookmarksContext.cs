namespace Bookmarks.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Migrations;

    public class BookmarksContext : IdentityDbContext<User>
    {
        public BookmarksContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookmarksContext, Configuration>());
        }

        public virtual IDbSet<Bookmark> Bookmarks { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Vote> Votes { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasRequired(c => c.Author)
                .WithMany(a => a.Comments)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Vote>()
                .HasRequired(v => v.User)
                .WithMany(u => u.Votes)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        public static BookmarksContext Create()
        {
            return new BookmarksContext();
        }
    }
}