namespace BookShopSystem.WebApplication.Models.ViewModels
{
    using BookShopSystem.Models;
    using System.Collections.Generic;

    public class AuthorViewModel
    {
        public AuthorViewModel(Author author)
        {
            this.Id = author.Id;
            this.FirstName = author.FirstName;
            this.LastName = author.LastName;
            this.BookTitles = new List<AuthorBooksTitlesViewModel>();

            foreach (var book in author.Books)
            {
                this.BookTitles.Add(new AuthorBooksTitlesViewModel(book));
            }
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<AuthorBooksTitlesViewModel> BookTitles { get; set; }
    }
}