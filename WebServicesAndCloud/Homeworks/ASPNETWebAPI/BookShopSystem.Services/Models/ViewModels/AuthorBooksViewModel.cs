namespace BookShopSystem.WebApplication.Models.ViewModels
{
    using BookShopSystem.Models;
    using System.Collections.Generic;

    public class AuthorBooksViewModel
    {
        public AuthorBooksViewModel(Book book)
        {
            this.Id = book.Id;
            this.Title = book.Title;
            this.Description = book.Description;
            this.Edition = book.Edition;
            this.Price = book.Price;
            this.Copies = book.Copies;
            this.Categories = new List<BookCategoriesViewModel>();

            foreach (var category in book.Categories)
            {
                this.Categories.Add(new BookCategoriesViewModel(category));
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public EditionType Edition { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public ICollection<BookCategoriesViewModel> Categories { get; set; }
    }
}