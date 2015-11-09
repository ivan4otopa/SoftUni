namespace Snippy.App.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using System.Linq;
    using Snippy.Models;
    using System;
    using Microsoft.AspNet.Identity;
    using AutoMapper;
    using Models;

    public class CommentsController : BaseController
    {
        public CommentsController(ISnippyData data)
            : base(data)
        {
        }
        
        public ActionResult Comment(int id, string content)
        {
            var snippet = this.Data.Snippets.All()
                .FirstOrDefault(s => s.Id == id);
            string userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.All()
                .FirstOrDefault(u => u.Id == userId);
            var newComment = new Comment()
            {
                Content = content,
                CreationTime = DateTime.Now,
                Author = user
            };

            snippet.Comments.Add(newComment);

            this.Data.SaveChanges();

            var commentModel = Mapper.Map<Comment, SnippetDetailsCommentViewModel>(newComment);
                                                      
            return this.PartialView("DisplayTemplates/SnippetDetailsCommentViewModel", commentModel);
        }
    }
}