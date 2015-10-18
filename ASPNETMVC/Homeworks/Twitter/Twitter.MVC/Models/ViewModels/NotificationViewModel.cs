namespace Twitter.MVC.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using Twitter.Models;

    public class NotificationViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public static Expression<Func<Notification, NotificationViewModel>> Create
        {
            get
            {
                return n => new NotificationViewModel()
                {
                    Id = n.Id,
                    Content = n.Content
                };
            }
        }
    }
}