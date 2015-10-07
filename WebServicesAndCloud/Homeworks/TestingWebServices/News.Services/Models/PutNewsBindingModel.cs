﻿namespace News.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PutNewsBindingModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PublishDate { get; set; }
    }
}