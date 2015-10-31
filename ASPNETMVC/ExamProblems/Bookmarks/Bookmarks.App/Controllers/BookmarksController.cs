namespace Bookmarks.App.Controllers
{
    using AutoMapper;
    using Models;
    using Data.UnitOfWork;
    using System.Linq;
    using System.Web.Mvc;
    using Bookmarks.Models;
    using Microsoft.AspNet.Identity;
    using System.Collections.Generic;

    public class BookmarksController : BaseController
    {
        public BookmarksController(IBookmarksData data)
            : base(data)
        {
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            var bookmark = this.Data.Bookmarks.All()
                .FirstOrDefault(b => b.Id == id);
            var bookmarkModel = Mapper.Map<Bookmark, BookmarkDetailsViewModel>(bookmark);

            return this.View(bookmarkModel);
        }

        [Authorize]
        public ActionResult Create()
        {
            var categories = this.Data.Categories.All()
                .Select(c =>
                    new SelectListItem()
                    {
                        Text = c.Name
                    });
            var createBookmarkModel = new CreateBookmarkModel();

            createBookmarkModel.BookmarkBindingModel = new BookmarkBindingModel();
            createBookmarkModel.Categories = categories;

            return this.View(createBookmarkModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateBookmarkModel model)
        {
            var category = this.Data.Categories.All()
                .FirstOrDefault(c => c.Name == model.BookmarkBindingModel.Category);
            string userId = this.User.Identity.GetUserId();

            this.Data.Bookmarks.Add(new Bookmark()
            {
                Title = model.BookmarkBindingModel.Title,
                URL = model.BookmarkBindingModel.URL,
                Description = model.BookmarkBindingModel.Description,
                CategoryId = category.Id,
                UserId = userId
            });
            this.Data.SaveChanges();           

            return this.RedirectToAction("Index", "Home");
        }
    }
}