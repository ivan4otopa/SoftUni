namespace BookShopSystem.WebApplication.Controllers
{
    using BookShopSystem.Data;
    using BookShopSystem.Models;
    using BookShopSystem.Services.Models.BindingModels;
    using BookShopSystem.Services.Models.ViewModels;
    using BookShopSystem.WebApplication.Models.BindingModels;
    using BookShopSystem.WebApplication.Models.ViewModels;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.OData;

    [EnableQuery]
    public class BooksController : ApiController
    {
        private BookShopSystemContext db = new BookShopSystemContext();

        public BookViewModel GetBook(int id)
        {
            var book = db.Books.Find(id);

            return new BookViewModel(book);
        }

        public IQueryable<SearchBooksViewModel> GetTop10Books(string search)
        {
            var books = db.Books.ToList();
            var top10Books = new List<SearchBooksViewModel>();

            foreach (var book in books)
            {
                if (book.Title.Contains(search))
                {
                    top10Books.Add(new SearchBooksViewModel(book));
                }
            }

            return top10Books
                .OrderBy(b => b.Title)
                .Take(10)
                .AsQueryable();
        }

        [HttpPut]
        public IHttpActionResult Edit(int id, [FromBody]EditBookBindingModel book)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var existingBook = db.Books.Find(id);

            existingBook.Title = book.Title;
            existingBook.Description = book.Description;
            existingBook.Price = book.Price;
            existingBook.Copies = book.Copies;
            existingBook.Edition = book.Edition;
            existingBook.AgeRestriction = book.AgeRestriction;
            existingBook.ReleaseDate = book.ReleaseDate;
            existingBook.AuthorId = book.AuthorId;

            db.SaveChanges();

            return this.Ok(new BookViewModel(existingBook));
        }

        public HttpResponseMessage Delete(int id)
        {
            var book = db.Books.Find(id);

            db.Books.Remove(book);
            db.SaveChanges();

            var response = new HttpResponseMessage();

            response.Headers.Add("DeleteMessage", "Book successfully deleted.");

            return response;
        }

        public IHttpActionResult Post([FromBody]BookBindingModel book)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newBook = new Book()
            {
                Title = book.Title,
                Description = book.Decription,
                Price = book.Price,
                Copies = book.Copies,
                Edition = book.Edition,
                AgeRestriction = book.AgeRestriction,
                ReleaseDate = book.ReleaseDate,
                AuthorId = db.Authors
                    .Where(a => a.FirstName == book.AuthorFirstName && a.LastName == book.AuthorLastName).FirstOrDefault().Id
            };

            db.Books.Add(newBook);
            db.SaveChanges();

            var categoriesNames = book.CategoryNames.Split(' ');
            var currentBook = db.Books.Where(b => b.Title == book.Title).FirstOrDefault();

            foreach (var categoryName in categoriesNames)
            {
                var currentCategory = db.Categories.Where(c => c.Name == categoryName).FirstOrDefault();

                currentCategory.Books.Add(currentBook);
            }

            db.SaveChanges();

            return this.Ok(new BookViewModel(currentBook));
        }

        [HttpPost]
        [Route("api/books/buy/{id}")]
        public IHttpActionResult BuyBook(int id, [FromBody]BuyBookBindingModel model)
        {
            var loggedUserId = this.User.Identity.GetUserId();

            if (loggedUserId == null)
            {
                return this.Unauthorized();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var book = db.Books.Find(id);
            var user = db.Users.Find(loggedUserId);
            var purchase = new Purchase()
            {
                Price = model.Price,
                DateOfPurchase = DateTime.Now,
                IsRecalled = false,
                ApplicationUser = user,
                Book = book
            };

            db.Purchases.Add(purchase);
            book.Copies--;
            db.SaveChanges();

            return this.Ok(new PurchaseViewModel(purchase));
        }

        [HttpPut]
        [Route("api/books/recall/{id}")]
        public IHttpActionResult ReturnBook(int id)
        {
            var purchase = db.Purchases.Where(p => p.BookId == id).FirstOrDefault();
            
            if (DateTime.Now > purchase.DateOfPurchase.AddDays(30))
            {
                return this.BadRequest("30 days have passed. You have to pay up.");    
            }

            purchase.IsRecalled = true;
            
            var book = db.Books.Find(id);

            book.Copies++;
            db.SaveChanges();

            return this.Ok(new PurchaseViewModel(purchase));
        }
    }
}
