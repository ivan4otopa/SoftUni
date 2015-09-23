namespace BookShopSystem.WebApplication.Controllers
{
    using BookShopSystem.Data;
    using BookShopSystem.Models;
    using BookShopSystem.WebApplication.Models.BindingModels;
    using BookShopSystem.WebApplication.Models.ViewModels;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.OData;

    [EnableQuery]
    public class AuthorsController : ApiController
    {
        private BookShopSystemContext db = new BookShopSystemContext();

        [Route("api/Authors/{id}")]
        [HttpGet]
        public AuthorViewModel GetAuthor(int id)
        {
            var author = db.Authors.Find(id);

            return new AuthorViewModel(author);
        }

        public IHttpActionResult Post([FromBody]AuthorBindingModel author)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newAuthor = new Author()
            {
                FirstName = author.FirstName,
                LastName = author.LastName
            };

            db.Authors.Add(newAuthor);


            db.SaveChanges();

            return this.Ok(newAuthor);
        }

        [Route("api/Authors/{id}/books")]
        [HttpGet]
        public IQueryable<AuthorBooksViewModel> GetAuthorBooks(int id)
        {
            var author = db.Authors.Find(id);

            var authorBooks = new List<AuthorBooksViewModel>();

            foreach (var book in author.Books)
            {
                authorBooks.Add(new AuthorBooksViewModel(book));
            }

            return authorBooks.AsQueryable();
        }
    }
}
