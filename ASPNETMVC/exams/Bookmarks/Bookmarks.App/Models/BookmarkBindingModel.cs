namespace Bookmarks.App.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class BookmarkBindingModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Title cannot be null")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(200, ErrorMessage = "{0} must be no more than {1} symbols long.")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Title cannot be null")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(200, ErrorMessage = "{0} must be no more than {1} symbols long.")]
        [DisplayName("Url")]
        public string URL { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }
    }
}