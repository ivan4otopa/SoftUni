namespace Bookmarks.App.Areas.Admin.Controllers
{
    using Models;
    using Data.UnitOfWork;
    using System.Web.Mvc;
    using System.Linq;

    public class CategoriesController : BaseAdminController
    {
        public CategoriesController(IBookmarksData data)
            : base(data)
        {
        }

        public ActionResult Categories()
        {
            var categories = this.Data.Categories.All();
             
            return View(categories);
        }

        public ActionResult Update(int id)
        {
            this.TempData["categoryId"] = id;

            return this.View();
        }

        [HttpPost]
        public ActionResult Update(int id, CategoryBindingModel model)
        {
            var category = this.Data.Categories.All()
                .FirstOrDefault(c => c.Id == id);

            category.Name = model.Name;

            this.Data.SaveChanges();

            return this.RedirectToAction("Categories");
        }
        
        public ActionResult Delete(int id)
        {
            var category = this.Data.Categories.All()
                .FirstOrDefault(c => c.Id == id);

            if (!category.Bookmarks.Any())
            {
                this.Data.Categories.Remove(category);
                this.Data.SaveChanges();

                return this.RedirectToAction("Categories");
            }
            else
            {
                return this.Content("Category has bookmarks, cannot delete");
            }
        }
    }
}