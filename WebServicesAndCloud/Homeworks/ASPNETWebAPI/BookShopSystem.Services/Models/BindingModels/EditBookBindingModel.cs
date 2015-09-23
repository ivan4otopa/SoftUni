namespace BookShopSystem.WebApplication.Models.BindingModels
{
    using BookShopSystem.Models;
    using System;

    public class EditBookBindingModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public EditionType Edition { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int AuthorId { get; set; }
    }
}