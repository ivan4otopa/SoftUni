namespace Bookmarks.App.Controllers
{
    using Data.UnitOfWork;
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Bookmarks.Models;

    public class VotesController : BaseController
    {
        public VotesController(IBookmarksData data)
            :base(data)
        {
        }
        
        public ActionResult Vote(int id)
        {
            var bookmark = this.Data.Bookmarks.All()
                .FirstOrDefault(b => b.Id == id);
            string userId = this.User.Identity.GetUserId();

            bookmark.Votes.Add(new Vote()
            {
                UserId = userId
            });

            this.Data.SaveChanges();

            return this.Json(bookmark.Votes.Count, JsonRequestBehavior.AllowGet);
        }
    }
}