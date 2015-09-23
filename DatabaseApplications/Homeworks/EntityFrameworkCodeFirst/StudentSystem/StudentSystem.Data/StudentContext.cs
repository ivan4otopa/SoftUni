namespace StudentSystem.Data
{
    using StudentSystem.Data.Migrations;
    using StudentSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class StudentContext : DbContext
    {
        public StudentContext()
            : base("StudentContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Resource> Resources { get; set; }

        public virtual DbSet<Homework> Homeworks { get; set; }
    }
}