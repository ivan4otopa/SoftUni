namespace Snippy.App.Models
{
    using System;

    public class CommentViewModel
    {
        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime CreationTime { get; set; }

        public CommentSnippetViewModel Snippet { get; set; }
    }
}