namespace News.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PostNewsBindingModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}