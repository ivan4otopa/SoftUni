namespace Snippy.App.Models
{
    using System.Collections.Generic;

    public class HomeViewModel
    {
        public IEnumerable<SnippetViewModel> Snippets { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public IEnumerable<LabelViewModel> Labels { get; set; }
    }
}