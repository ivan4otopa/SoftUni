namespace Bookmarks.App.Models
{
    using System.Collections.Generic;

    public class BookmarkDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string URL { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public int VotesCount { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}