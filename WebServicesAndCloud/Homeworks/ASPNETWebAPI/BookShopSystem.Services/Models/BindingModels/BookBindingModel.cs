namespace BookShopSystem.WebApplication.Models.BindingModels
{
    using BookShopSystem.Models;
    using System;

    public class BookBindingModel
    {
        public string Title { get; set; }

        public string Decription { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public EditionType Edition { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string CategoryNames { get; set; }

        public string AuthorFirstName { get; set; }

        public string AuthorLastName { get; set; }
    }
}