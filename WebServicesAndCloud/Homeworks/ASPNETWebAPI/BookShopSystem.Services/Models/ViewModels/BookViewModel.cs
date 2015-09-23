namespace BookShopSystem.WebApplication.Models.ViewModels
{
    using BookShopSystem.Models;
    using System.Collections.Generic;

    public class BookViewModel
    {
        public BookViewModel(Book book)
        {
            this.Id = book.Id;
            this.Title = book.Title;
            this.Description = book.Description;
            this.Edition = book.Edition;
            this.Price = book.Price;
            this.Copies = book.Copies;
            this.AuthorName = book.Author.FirstName + " " + book.Author.LastName;
            this.AuthorId = book.Author.Id;
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

        public string AuthorName { get; set; }

        public int AuthorId { get; set; }

        public ICollection<BookCategoriesViewModel> Categories { get; set; }
    }
}