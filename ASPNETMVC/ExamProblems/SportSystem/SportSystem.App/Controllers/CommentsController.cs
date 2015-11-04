namespace SportSystem.App.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using System.Linq;
    using SportSystem.Models;
    using System;
    using Microsoft.AspNet.Identity;
    using AutoMapper;
    using Models.ViewModels;

    [Authorize]
    public class CommentsController : BaseController
    {
        public CommentsController(ISportSystemData data)
            : base(data)
        {
        }
        
        public ActionResult Add(int id, string content)
        {
            var match = this.Data.Matches.All()
                .FirstOrDefault(m => m.Id == id);
            string userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.All()
                .FirstOrDefault(u => u.Id == userId);
            var newComment = new Comment()
            {
                Content = content,
                DateAndTime = DateTime.Now,
                OwnerId = userId
            };

            match.Comments.Add(newComment);

            this.Data.SaveChanges();

            var commentModel = Mapper.Map<Comment, CommentViewModel>(newComment);

            return this.PartialView("DisplayTemplates/CommentViewModel", commentModel);
        }
    }
}