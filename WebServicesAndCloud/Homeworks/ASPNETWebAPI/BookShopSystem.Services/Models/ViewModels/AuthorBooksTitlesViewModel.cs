namespace BookShopSystem.WebApplication.Models.ViewModels
{
    using BookShopSystem.Models;

    public class AuthorBooksTitlesViewModel
    {
        public AuthorBooksTitlesViewModel(Book book)
        {
            this.Title = book.Title;
        }

        public string Title { get; set; }
    }
}
