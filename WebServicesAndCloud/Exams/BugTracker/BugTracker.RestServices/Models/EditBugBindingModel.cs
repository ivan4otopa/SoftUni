namespace BugTracker.RestServices.Models
{
    using System.ComponentModel.DataAnnotations;

    public class EditBugBindingModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Status { get; set; }
    }
}