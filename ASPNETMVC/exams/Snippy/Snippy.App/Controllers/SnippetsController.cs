namespace Snippy.App.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using System.Linq;
    using AutoMapper;
    using System.Collections.Generic;
    using Models;
    using Snippy.Models;
    using Microsoft.AspNet.Identity;
    using System;

    public class SnippetsController : BaseController
    {
        public SnippetsController(ISnippyData data)
            : base(data)
        {
        }
        
        public ActionResult All()
        {
            var snippets = this.Data.Snippets.All()
                .OrderByDescending(s => s.CreationTime);
            var snippetModels = Mapper.Map<IEnumerable<Snippet>, IEnumerable<SnippetViewModel>>(snippets);

            return View(snippetModels);
        }

        public ActionResult Details(int id)
        {
            var snippet = this.Data.Snippets.All()
                .FirstOrDefault(s => s.Id == id);
            var snippetModel = Mapper.Map<Snippet, SnippetDetailsViewModel>(snippet);

            snippetModel.Comments = snippetModel.Comments
                .OrderByDescending(c => c.CreationTime);

            this.TempData["Title"] = snippet.Title;
            this.TempData["SnippetId"] = id;

            return this.View(snippetModel);
        }

        [Authorize]
        public ActionResult My()
        {
            string userId = this.User.Identity.GetUserId();
            var snippets = this.Data.Snippets.All()
                .Where(s => s.AuthorId == userId);
            var snippetModels = Mapper.Map<IEnumerable<Snippet>, IEnumerable<SnippetViewModel>>(snippets);

            return this.View(snippetModels);
        }

        [Authorize]
        public ActionResult Create()
        {
            var languages = this.Data.Languages.All()
                .Select(l =>
                    new SelectListItem()
                    {
                        Text = l.Name
                    });
            var createSnippetModel = new CreateSnippetModel();

            createSnippetModel.SnippetBindingModel = new SnippetBindingModel();
            createSnippetModel.Languages = languages;

            return this.View(createSnippetModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(CreateSnippetModel model)
        {
            string userId = this.User.Identity.GetUserId();

            var newSnippet = new Snippet()
            {
                Title = model.SnippetBindingModel.Title,
                Description = model.SnippetBindingModel.Description,
                Code = model.SnippetBindingModel.Code,
                CreationTime = DateTime.Now,
                LanguageName = model.SnippetBindingModel.Language,
                AuthorId = userId
            };

            this.Data.Snippets.Add(newSnippet);
            this.Data.SaveChanges();

            var snippet = this.Data.Snippets.All()
                .FirstOrDefault(s => s.Id == newSnippet.Id);
            var labels = model.SnippetBindingModel.Labels.Split(';');

            foreach (var labelText in labels)
            {
                var label = this.Data.Labels.All()
                    .FirstOrDefault(l => l.Text == labelText.Trim());

                if (label == null)
                {
                    var newLabel = new Label()
                    {
                        Text = labelText.Trim()
                    };

                    snippet.Labels.Add(newLabel);
                }
                else
                {
                    snippet.Labels.Add(label);
                }
            }

            this.Data.SaveChanges();

            return this.RedirectToAction("Details", "Snippets", new { id = snippet.Id });
        }

        [Authorize]
        public ActionResult Edit()
        {
            var languages = this.Data.Languages.All()
                .Select(l =>
                    new SelectListItem()
                    {
                        Text = l.Name
                    });
            var editSnippetModel = new EditSnippetModel();

            editSnippetModel.SnippetBindingModel = new SnippetBindingModel();
            editSnippetModel.Languages = languages;
            editSnippetModel.Title = this.TempData["Title"].ToString();
            editSnippetModel.SnippetId = (int)this.TempData["SnippetId"];

            return this.View(editSnippetModel);
        }

        [Authorize]
        public ActionResult EditSnippet(int id, EditSnippetModel model)
        {
            var snippet = this.Data.Snippets.All()
                .FirstOrDefault(s => s.Id == id);

            snippet.Title = model.SnippetBindingModel.Title;
            snippet.Description = model.SnippetBindingModel.Description;
            snippet.Code = model.SnippetBindingModel.Code;
            snippet.LanguageName = model.SnippetBindingModel.Language;     

            foreach (var label in snippet.Labels.ToList())
            {
                snippet.Labels.Remove(label);
            }

            this.Data.SaveChanges();

            var labels = model.SnippetBindingModel.Labels.Split(';');

            foreach (var labelText in labels)
            {
                var label = this.Data.Labels.All()
                    .FirstOrDefault(l => l.Text == labelText.Trim());

                if (label == null)
                {
                    var newLabel = new Label()
                    {
                        Text = labelText.Trim()
                    };

                    snippet.Labels.Add(newLabel);
                }
                else
                {
                    snippet.Labels.Add(label);
                }
            }

            this.Data.SaveChanges();

            return this.RedirectToAction("Details", "Snippets", new { id = snippet.Id });
        }

        public ActionResult Search(string searchText)
        {
            var snippets = this.Data.Snippets.All()
                .Where(s => s.Title.Contains(searchText) || s.Labels
                    .Any(l => l.Text.Contains(searchText)));
            var snippetModels = Mapper.Map<IEnumerable<Snippet>, IEnumerable<SnippetViewModel>>(snippets);

            return this.View(snippetModels);
        }
    }
}