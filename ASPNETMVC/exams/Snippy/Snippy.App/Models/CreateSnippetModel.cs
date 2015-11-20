namespace Snippy.App.Models
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class CreateSnippetModel
    {
        public SnippetBindingModel SnippetBindingModel { get; set; }

        public IEnumerable<SelectListItem> Languages { get; set; }
    }
}