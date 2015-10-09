namespace Twitter.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Profile
    {
        [Key, ForeignKey("User")]
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
