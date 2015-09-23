namespace News.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class NewsModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
