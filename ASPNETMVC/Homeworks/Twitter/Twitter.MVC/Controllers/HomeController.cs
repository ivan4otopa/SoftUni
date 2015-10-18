namespace Twitter.MVC.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using System.Linq;
    using Models.ViewModels;
    using Microsoft.AspNet.Identity;

    public class HomeController : BaseController
    {
        public HomeController(ITwitterData data)
            : base(data)
        {
        }

        public ActionResult Index(int page = 1)
        {
            IQueryable<TweetViewModel> tweets = null;

            string userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.All()
                .FirstOrDefault(u => u.Id == userId);

            if (userId == null)
            {
                tweets = this.Data.Tweets.All()
                    .OrderByDescending(t => t.CreatedOn)
                    .Select(TweetViewModel.Create)
                    .Skip((page - 1) * 10)
                    .Take(10);
            }
            else
            {
                var followedUsersIds = user.Following
                    .Select(f => f.Id)
                    .ToList();

                tweets = this.Data.Tweets.All()
                    .Where(t => followedUsersIds.Contains(t.UserId))
                    .OrderByDescending(t => t.CreatedOn)
                    .Select(TweetViewModel.Create)
                    .Skip((page - 1) * 10)
                    .Take(10);
            }

            return View(tweets);
        }
    }
}