namespace Snippy.Data
{
    using System.Data.Entity;

    using Models;

    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;

    public class SnippyContext : IdentityDbContext<User>, ISnippyContext
    {
        public SnippyContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SnippyContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Snippet>()
                .HasRequired(s => s.Author)
                .WithMany(a => a.Snippets)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Snippet>()
                .HasRequired(s => s.Language)
                .WithMany(l => l.Snippets)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<Snippet> Snippets { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Language> Languages { get; set; }

        public IDbSet<Label> Labels { get; set; }

        public static SnippyContext Create()
        {
            return new SnippyContext();
        }
    }
}
