namespace Snippy.App.Models
{
    using System.Collections.Generic;

    public class SnippetViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<SnippetLabelViewModel> Labels { get; set; }
    }
}