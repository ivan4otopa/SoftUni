namespace BookShopSystem.Services.Models.ViewModels
{
    using BookShopSystem.Models;
    using System;

    public class PurchaseViewModel
    {
        public PurchaseViewModel(Purchase purchase)
        {
            this.Id = purchase.Id;
            this.Price = purchase.Price;
            this.DateOfPurchase = purchase.DateOfPurchase;
            this.IsRecalled = purchase.IsRecalled;
            this.ApplicationUser = purchase.ApplicationUser.UserName;
            this.Book = purchase.Book.Title;
        }

        public int Id { get; set; }

        public decimal Price { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public bool IsRecalled { get; set; }

        public string ApplicationUser { get; set; }

        public string Book { get; set; }
    }
}