namespace BugTracker.RestServices.Models
{
    using BugTracker.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class BugDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public static Expression<Func<Bug, BugDetailsViewModel>> Create
        {
            get
            {
                return b => new BugDetailsViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    Status = b.Status.ToString(),
                    Author = b.Author == null ? null : b.Author.UserName,
                    DateCreated = b.SubmitDate,
                    Comments = b.Comments
                        .OrderByDescending(c => c.PublishDate)
                        .Select(c => new CommentViewModel()
                        {
                            Id = c.Id,
                            Text = c.Text,
                            Author = c.Author == null ? null : c.Author.UserName,
                            DateCreated = c.PublishDate
                        })
                };
            }
        }
    }
}