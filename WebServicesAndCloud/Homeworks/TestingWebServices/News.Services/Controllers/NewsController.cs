namespace News.Services.Controllers
{
    using News.Models;
    using Models;
    using System.Linq;
    using System.Web.Http;
    using System;
    using Data;
    using System.Security.Policy;
    using System.Web;

    public class NewsController : BaseApiController
    {
        public NewsController(INewsData data)
            : base(data)
        {
        }

        public NewsController()
        {

        }

        public IHttpActionResult Get()
        {
            var news = this.Data.News.All()
                .OrderByDescending(n => n.PublishDate);

            return this.Ok(news);
        }

        public IHttpActionResult Post([FromBody]PostNewsBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newNews = new NewsModel()
            {
                Title = model.Title,
                Content = model.Content,
                PublishDate = DateTime.Now
            };

            this.Data.News.Add(newNews);
            this.Data.SaveChanges();

            return this.Created("api/news", newNews);
        }

        public IHttpActionResult Put(int id, [FromBody]PutNewsBindingModel model)
        {
            var news = this.Data.News.Find(id);

            if (news == null)
            {
                return this.BadRequest(string.Format("News with id {0} does not exist", id));
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            news.Title = model.Title;
            news.Content = model.Content;
            news.PublishDate = model.PublishDate;

            this.Data.SaveChanges();

            return this.Ok(news);
        }

        public IHttpActionResult Delete(int id)
        {
            var news = this.Data.News.Find(id);

            if (news == null)
            {
                return this.BadRequest(string.Format("News with id {0} does not exist", id));
            }

            this.Data.News.Delete(news);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}
