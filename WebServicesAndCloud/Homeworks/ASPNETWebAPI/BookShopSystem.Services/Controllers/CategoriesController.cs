namespace BookShopSystem.WebApplication.Controllers
{
    using BookShopSystem.Data;
    using BookShopSystem.Models;
    using BookShopSystem.WebApplication.Models.BindingModels;
    using BookShopSystem.WebApplication.Models.ViewModels;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.OData;

    [EnableQuery]
    public class CategoriesController : ApiController
    {
        private BookShopSystemContext db = new BookShopSystemContext();

        public IQueryable<CategoryViewModel> GetAllCategories()
        {
            var categories = new List<CategoryViewModel>();

            foreach (var category in db.Categories)
            {
                categories.Add(new CategoryViewModel(category));
            }

            return categories.AsQueryable();
        }

        public CategoryViewModel GetCategory(int id)
        {
            var category = db.Categories.Find(id);

            return new CategoryViewModel(category);
        }

        public IHttpActionResult PutCategory(int id, [FromBody]CategoryBindingModel category)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            foreach (var currentCategory in db.Categories)
            {
                if (currentCategory.Name == category.Name)
                {
                    return this.BadRequest();
                }
            }

            var existingCategory = db.Categories.Find(id);

            existingCategory.Name = category.Name;
            db.SaveChanges();

            return this.Ok(new CategoryViewModel(existingCategory));
        }

        public HttpResponseMessage DeleteCategory(int id)
        {
            var category = db.Categories.Find(id);

            db.Categories.Remove(category);
            db.SaveChanges();

            var responce = new HttpResponseMessage();

            responce.Headers.Add("DeleteMessage", "Category successfully deleted.");

            return responce;
        }

        public IHttpActionResult PostCategory([FromBody]CategoryBindingModel category)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            foreach (var currentCategory in db.Categories)
            {
                if (currentCategory.Name == category.Name)
                {
                    return this.BadRequest();
                }
            }

            var newCategory = new Category()
            {
                Name = category.Name
            };

            db.Categories.Add(newCategory);
            db.SaveChanges();

            return this.Ok(new CategoryViewModel(newCategory));
        }
    }
}
