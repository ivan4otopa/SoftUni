using AutoMapper;
using Bookmarks.App.Models;
using Bookmarks.Data.UnitOfWork;
using Bookmarks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookmarks.App.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IBookmarksData data)
            : base(data)
        {
        }

        public ActionResult Index(bool allBookmarks = false)
        {
            IQueryable<Bookmark> bookmarks = null;

            IEnumerable<BookmarkViewModel> bookmarkModels = null;

            if (!allBookmarks)
            {
                bookmarks = this.Data.Bookmarks.All()
                    .OrderByDescending(b => b.Votes.Count)
                    .Take(6);

                bookmarkModels = Mapper.Map<IEnumerable<Bookmark>, IEnumerable<BookmarkViewModel>>(bookmarks);

                return View(bookmarkModels);
            }
            else
            {
                bookmarks = this.Data.Bookmarks.All()
                    .OrderByDescending(b => b.Votes.Count);

                bookmarkModels = Mapper.Map<IEnumerable<Bookmark>, IEnumerable<BookmarkViewModel>>(bookmarks);

                return Json(new { bookmarks = bookmarkModels, isAuthenticated = this.User.Identity.IsAuthenticated }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}