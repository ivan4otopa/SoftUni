namespace BookShopSystem.WebApplication.Models.ViewModels
{
    using BookShopSystem.Models;

    public class SearchBooksViewModel
    {
        public SearchBooksViewModel(Book book)
        {
            this.Title = book.Title;
            this.Id = book.Id;
        }

        public string Title { get; set; }

        public int Id { get; set; }
    }
}