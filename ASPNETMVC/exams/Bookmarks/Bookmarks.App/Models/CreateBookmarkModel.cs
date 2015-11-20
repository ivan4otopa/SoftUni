namespace Bookmarks.App.Models
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class CreateBookmarkModel
    {
        public BookmarkBindingModel BookmarkBindingModel { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}