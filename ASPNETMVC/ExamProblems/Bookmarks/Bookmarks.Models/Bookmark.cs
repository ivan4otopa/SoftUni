namespace Bookmarks.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Bookmark
    {
        private const int MaximumTitleLength = 200;
        private const int MaximumURLLength = 200;

        private ICollection<Vote> votes;
        private ICollection<Comment> comments;

        public Bookmark()
        {
            this.Votes = new HashSet<Vote>();
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(MaximumTitleLength, ErrorMessage = "{0} should be no more than {1} symbols long.")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(MaximumURLLength, ErrorMessage = "{0} should be no more than {1} symbols long.")]
        public string URL { get; set; }        
        
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Vote> Votes
        {
            get
            {
                return this.votes;
            }

            set
            {
                this.votes = value;
            }
        }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }

            set
            {
                this.comments = value;
            }
        }
    }
}
