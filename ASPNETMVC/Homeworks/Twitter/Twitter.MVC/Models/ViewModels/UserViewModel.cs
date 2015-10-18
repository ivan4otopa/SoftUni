namespace Twitter.MVC.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using Twitter.Models;

    public class UserViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public static Expression<Func<User, UserViewModel>> Create
        {
            get
            {
                return u => new UserViewModel()
                {
                    Id = u.Id,
                    Username = u.UserName
                };
            }
        }
    }
}