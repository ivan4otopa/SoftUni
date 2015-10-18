namespace Twitter.MVC.Models.ViewModels
{
    using System.Collections.Generic;

    public class ProfileViewModel
    {
        public ICollection<TweetViewModel> Tweets { get; set; }

        public ICollection<UserViewModel> Following { get; set; }

        public ICollection<UserViewModel> Followers { get; set; }

        public ICollection<TweetViewModel> FavouriteTweets { get; set; }
    }
}