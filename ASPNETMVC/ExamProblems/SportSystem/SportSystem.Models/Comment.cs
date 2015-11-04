namespace SportSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} is required.")]
        public string Content { get; set; }

        public DateTime DateAndTime { get; set; }

        public int MatchId { get; set; }

        public virtual Match Match { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }
    }
}
