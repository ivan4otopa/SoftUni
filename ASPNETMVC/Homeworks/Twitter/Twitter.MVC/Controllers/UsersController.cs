namespace Twitter.MVC.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using Microsoft.AspNet.Identity;
    using System.Linq;
    using Twitter.Models;
    using Models.ViewModels;
    using Models.BindingModels;
    using System.Web.Security;

    public class UsersController : BaseController
    {
        public UsersController(ITwitterData data)
            : base(data)
        {
        }

        public ActionResult Profile()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                string userId = this.User.Identity.GetUserId();
                var user = this.Data.Users.All()
                    .FirstOrDefault(u => u.Id == userId);

                IQueryable<TweetViewModel> tweets = this.Data.Tweets.All()
                    .Where(t => t.UserId == userId)
                    .Select(TweetViewModel.Create);
                IQueryable<UserViewModel> following = user.Following
                    .AsQueryable()
                    .Select(UserViewModel.Create);
                IQueryable<UserViewModel> followers = user.Followers
                    .AsQueryable()
                    .Select(UserViewModel.Create);
                IQueryable<TweetViewModel> favouriteTweets = user.FavouriteTweets
                    .AsQueryable()
                    .Select(TweetViewModel.Create);
                ProfileViewModel profileViewModel = new ProfileViewModel();

                profileViewModel.Tweets = tweets.ToList();
                profileViewModel.Following = following.ToList();
                profileViewModel.Followers = followers.ToList();
                profileViewModel.FavouriteTweets = favouriteTweets.ToList();

                return View(profileViewModel);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult EditProfile()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                UserBindingModel ubm = new UserBindingModel();

                return View(ubm);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult EditProfile(UserBindingModel model)
        {
            string userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.All()
                .FirstOrDefault(u => u.Id == userId);

            user.Email = model.Username;
            user.UserName = model.Username;

            this.Data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}