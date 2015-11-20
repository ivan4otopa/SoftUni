namespace Bookmarks.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        private const int MaximumNameLength = 100;

        private ICollection<Bookmark> bookmarks;

        public Category()
        {
            this.Bookmarks = new HashSet<Bookmark>();
        }

        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(MaximumNameLength, ErrorMessage = "{0} should be no more than {1} symbols long.")]
        public string Name { get; set; }

        public virtual ICollection<Bookmark> Bookmarks
        {
            get
            {
                return this.bookmarks;
            }

            set
            {
                this.bookmarks = value;
            }
        }
    }
}
