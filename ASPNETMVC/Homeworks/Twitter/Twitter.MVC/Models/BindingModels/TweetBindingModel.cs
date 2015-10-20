using System.ComponentModel.DataAnnotations;

namespace Twitter.MVC.Models.BindingModels
{
    public class TweetBindingModel
    {
        [Required(ErrorMessage = "Enter text")]
        [StringLength(250, ErrorMessage = "No more than 250 symbols")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}