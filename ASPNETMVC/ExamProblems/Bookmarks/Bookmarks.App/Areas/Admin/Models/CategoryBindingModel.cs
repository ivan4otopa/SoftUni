namespace Bookmarks.App.Areas.Admin.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryBindingModel
    {
        private const int MaximumNameLength = 100;

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(MaximumNameLength, ErrorMessage = "{0} should be no more than {1} symbols long.")]
        public string Name { get; set; }
    }
}