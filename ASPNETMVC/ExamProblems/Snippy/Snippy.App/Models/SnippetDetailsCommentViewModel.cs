namespace Snippy.App.Models
{
    using System;

    public class SnippetDetailsCommentViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime CreationTime { get; set; }

        public int SnippetId { get; set; }

        public string AuthorId { get; set; }
    }
}