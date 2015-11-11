namespace Snippy.App.Models
{
    using System;
    using System.Collections.Generic;

    public class SnippetDetailsViewModel
    {
        public int Id { get; set; }

        public string LanguageName { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime CreationTime { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public IEnumerable<SnippetLabelViewModel> Labels { get; set; }

        public IEnumerable<SnippetDetailsCommentViewModel> Comments { get; set; }
    }
}