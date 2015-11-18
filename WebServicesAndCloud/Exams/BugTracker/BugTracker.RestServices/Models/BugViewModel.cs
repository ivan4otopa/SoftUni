namespace BugTracker.RestServices.Models
{
    using BugTracker.Data.Models;
    using System;
    using System.Linq.Expressions;

    public class BugViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }

        public static Expression<Func<Bug, BugViewModel>> Create
        {
            get
            {
                return b => new BugViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Status = b.Status.ToString(),
                    Author = b.Author == null ? null : b.Author.UserName,
                    DateCreated = b.SubmitDate
                };
            }
        }
    }
}