namespace Bookmarks.App.Controllers
{
    using Bookmarks.Models;
    using Data.UnitOfWork;
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;

    public class CommentsController : BaseController
    {
        public CommentsController(IBookmarksData data)
            : base(data)
        {
        }

        public ActionResult Comment(int id, string text)
        {
            var bookmark = this.Data.Bookmarks.All()
                .FirstOrDefault(b => b.Id == id);
            string userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.All()
                .FirstOrDefault(u => u.Id == userId);

            bookmark.Comments.Add(new Comment()
            {
                Text = text,
                AuthorId = userId,
            });

            this.Data.SaveChanges();

            return this.Json(new { Text = text, Author = user.UserName }, JsonRequestBehavior.AllowGet);
        }
    }
}