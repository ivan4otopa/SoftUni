namespace BugTracker.RestServices.Controllers
{
    using BugTracker.Data.Models;
    using BugTracker.Data.Models.Enums;
    using Microsoft.AspNet.Identity;
    using Models;
    using System;
    using System.Data;
    using System.Linq;
    using System.Web.Http;

    public class BugsController : BaseApiController
    {
        public IHttpActionResult GetAll()
        {
            var bugs = this.Data.Bugs
                .OrderByDescending(b => b.SubmitDate)
                .Select(BugViewModel.Create);

            return this.Ok(bugs);
        }

        public IHttpActionResult GetById(int id)
        {
            var bug = this.Data.Bugs
                .Where(b => b.Id == id)
                .Select(BugDetailsViewModel.Create)
                .FirstOrDefault();

            if (bug == null)
            {
                return this.NotFound();
            }

            return this.Ok(bug);
        }

        public IHttpActionResult Submit([FromBody]SubmitBugBindingModel model)
        {
            if (model == null)
            {
                this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            string userId = this.User.Identity.GetUserId();
            var user = this.Data.Users
                .FirstOrDefault(u => u.Id == userId);

            var newBug = new Bug()
            {
                Title = model.Title,
                Description = model.Description,
                Status = Status.Open,
                SubmitDate = DateTime.Now,
                Author = user
            };

            this.Data.Bugs.Add(newBug);
            this.Data.SaveChanges();

            if (newBug.Author == null)
            {
                return this.CreatedAtRoute("DefaultApi", new { Id = newBug.Id }, new 
                { 
                    Id = newBug.Id,
                    Message = "Anonymous bug submitted."
                });
            }
            else
            {
                return this.CreatedAtRoute("DefaultApi", new { Id = newBug.Id }, new
                {
                    Id = newBug.Id,
                    Author = newBug.Author.UserName,
                    Message = "User bug submitted."
                });
            }
        }

        [HttpPatch]
        public IHttpActionResult Edit(int id, [FromBody]EditBugBindingModel model)
        {
            var bug = this.Data.Bugs
                .FirstOrDefault(b => b.Id == id);

            if (bug == null)
            {
                return this.NotFound();
            }

            if (model == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            bug.Title = model.Title;
            bug.Description = model.Description;
            bug.Status = (Status)Enum.Parse(typeof(Status), model.Status);

            this.Data.SaveChanges();

            return this.Ok(new 
            {
                Message = string.Format("Bug #{0} patched.", id)
            });
        }

        public IHttpActionResult Delete(int id)
        {
            var bug = this.Data.Bugs
                .FirstOrDefault(b => b.Id == id);

            if (bug == null)
            {
                return this.NotFound();
            }

            foreach (var comment in bug.Comments.ToList())
            {
                this.Data.Comments.Remove(comment);
            }

            this.Data.Bugs.Remove(bug);
            this.Data.SaveChanges();

            return this.Ok(new
            {
                Message = string.Format("Bug #{0} deleted.", id)
            });
        }
        
        [Route("api/bugs/{keyword?}/{statuses?}/{author?}")]
        public IHttpActionResult GetByFilter([FromUri]string keyword = null, [FromUri]string statuses = null, [FromUri]string author = null)
        {
            IQueryable<Bug> bugs = this.Data.Bugs;

            if (keyword != null)
            {
                bugs = bugs
                    .Where(b => b.Title.Contains(keyword));
            }

            if (statuses != null)
            {
                var statusesList = statuses.Split('|').ToList();

                foreach (var status in statusesList)
                {
                    bugs = bugs
                        .Where(b => b.Status.ToString() == status);
                }
            }

            if (author != null)
            {
                bugs = bugs
                    .Where(b => b.Author.UserName == author);
            }

            var detailedBugs = bugs
                .OrderByDescending(b => b.SubmitDate)
                .Select(BugViewModel.Create);

            return this.Ok(detailedBugs);
        }
    }
}
