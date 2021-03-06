﻿namespace Twitter.MVC.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using Models.BindingModels;
    using Twitter.Models;
    using System;
    using Microsoft.AspNet.Identity;
    using System.Linq;
    using Hubs;
    using Microsoft.AspNet.SignalR;

    public class TweetsController : BaseController
    {
        public TweetsController(ITwitterData data)
            : base(data)
        {
        }

        [ValidateAntiForgeryToken]
        public ActionResult PostTweet(TweetBindingModel model)
        {
            string userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.All()
                .FirstOrDefault(u => u.Id == userId);

            if (!this.ModelState.IsValid)
            {
                this.TempData["resultMessage"] = "Error";
            }
            else
            { 
                var newTweet = new Tweet()
                {
                    Content = model.Content,
                    CreatedOn = DateTime.Now,
                    URL = "asd",
                    UserId = userId
                };

                this.Data.Tweets.Add(newTweet);
                this.Data.SaveChanges();
                this.TempData["resultMessage"] = "Success";
            }

            var data = this.TempData["resultMessage"];
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<TweetsHub>();

            hubContext.Clients.All.receiveTweet(user.UserName, model.Content);

            return Content("Tweeted");
        }

        public ActionResult Favourite(int id, string destination)
        {
            string userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.All()
                .FirstOrDefault(u => u.Id == userId);
            var tweet = this.Data.Tweets.Find(id);

            user.FavouriteTweets.Add(tweet);

            var notifiedUser = tweet.User;

            notifiedUser.Notifications.Add(new Notification()
            {
                Content = string.Format("User {0} favourited your tweet", user.UserName),
                CreatedOn = DateTime.Now
            });

            this.Data.SaveChanges();

            if (destination == "Index")
            {
                return RedirectToAction(destination, "Home");
            }
            else
            {
                return RedirectToAction(destination, "Users");
            }
        }

        public ActionResult Retweet(int id, string destination)
        {
            ViewBag.Id = id;
            ViewBag.Destination = destination;

            TweetBindingModel tweetBindingModel = new TweetBindingModel();

            return View(tweetBindingModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Retweet(TweetBindingModel model, int id, string destination)
        {
            var tweet = this.Data.Tweets.Find(id);
            string userId = this.User.Identity.GetUserId();

            tweet.Retweets.Add(new Tweet()
            {
                Content = model.Content,
                CreatedOn = DateTime.Now,
                URL = "asd",
                UserId = userId
            });

            var notifiedUser = tweet.User;

            notifiedUser.Notifications.Add(new Notification()
            {
                Content = string.Format("User {0} retweeted your tweet", this.User.Identity.GetUserName()),
                CreatedOn = DateTime.Now
            });

            this.Data.SaveChanges();

            if (destination == "Index")
            {
                return RedirectToAction(destination, "Home");
            }
            else
            {
                return RedirectToAction(destination, "Users");
            }
        }
    }
}