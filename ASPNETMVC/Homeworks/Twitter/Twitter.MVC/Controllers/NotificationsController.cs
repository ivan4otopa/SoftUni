namespace Twitter.MVC.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using Microsoft.AspNet.Identity;
    using System.Linq;
    using Models.ViewModels;
    using Hubs;
    using Microsoft.AspNet.SignalR;

    public class NotificationsController : BaseController
    {
        public NotificationsController(ITwitterData data)
            : base(data)
        {
        }

        public ActionResult Notifications()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                string userId = this.User.Identity.GetUserId();
                var notifications = this.Data.Notifications.All()
                    .Where(n => n.UserId == userId)
                    .Select(NotificationViewModel.Create);

                return View(notifications);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Notification(int id)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                string userId = this.User.Identity.GetUserId();
                var notification = this.Data.Notifications.All()
                    .Where(n => n.UserId == userId)
                    .Select(NotificationViewModel.Create)
                    .FirstOrDefault(n => n.Id == id);

                return View(notification);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}