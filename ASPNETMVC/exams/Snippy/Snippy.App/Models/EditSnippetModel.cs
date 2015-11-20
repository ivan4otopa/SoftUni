namespace Snippy.App.Models
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class EditSnippetModel
    {
        public string Title { get; set; }

        public int SnippetId { get; set; }

        public SnippetBindingModel SnippetBindingModel { get; set; }

        public IEnumerable<SelectListItem> Languages { get; set; }
    }
}