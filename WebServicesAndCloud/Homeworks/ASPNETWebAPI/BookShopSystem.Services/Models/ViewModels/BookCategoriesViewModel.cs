namespace BookShopSystem.WebApplication.Models.ViewModels
{
    using BookShopSystem.Models;

    public class BookCategoriesViewModel
    {
        public BookCategoriesViewModel(Category category)
        {
            this.Name = category.Name;
        }

        public string Name { get; set; }
    }
}
