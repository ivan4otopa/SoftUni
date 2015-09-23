using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace News.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Owin.Testing;
    using System.Net.Http;
    using System.Web.Http;
    using Services;
    using Owin;
    using Data;
    using Models;
    using System.Collections.Generic;
    using System.Net;
    using System.Linq;

    [TestClass]
    public class NewsIntegrationServices
    {
        private TestServer httpTestServer;
        private HttpClient httpClient;

        [TestInitialize]
        public void TestInit()
        {
            this.httpTestServer = TestServer.Create(appBuilder =>
            {
                var config = new HttpConfiguration();

                WebApiConfig.Register(config);
                appBuilder.UseWebApi(config);
            });
            this.httpClient = httpTestServer.HttpClient;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.httpTestServer.Dispose();
        }

        [TestMethod]
        public void Get_ShouldReturn200OKPlusAllNewsItemsAsJSON()
        {
            var response = httpClient.GetAsync("/api/news").Result;
            var news = response.Content.ReadAsAsync<List<NewsModel>>().Result;
            
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(response.Content.Headers.ContentType.MediaType, "application/json");
            Assert.AreEqual(3, news.Count);
        }

        [TestMethod]
        public void Post_ShouldReturn201CreatedPlusTheNewlyCreatedItemOnCorrectData()
        {
            var context = new NewsContext();
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("title", "New news"),
                new KeyValuePair<string, string>("content", "The news is new")
            });

            var response = httpClient.PostAsync("api/news", content).Result;
            var news = response.Content.ReadAsAsync<NewsModel>().Result;

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.AreEqual("New news", news.Title);
            Assert.AreEqual("The news is new", news.Content);
            Assert.AreEqual(4, context.News.Count());

            context.News.Attach(news);
            context.News.Remove(news);
            context.SaveChanges();
        }

        [TestMethod]
        public void Post_ShouldReturn400BadRequestOnNullTitle()
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("title", null),
                new KeyValuePair<string, string>("content", "Null title")
            });

            var response = httpClient.PostAsync("api/news", content).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Post_ShouldReturn400BadRequestOnNullContent()
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("title", "Null content"),
                new KeyValuePair<string, string>("content", null)
            });

            var response = httpClient.PostAsync("api/news", content).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Put_ShouldReturn200OKOnCorrectData()
        {
            var context = new NewsContext();
            var updateNews = new NewsModel()
            {
                Title = "Update news title",
                Content = "Update news content",
                PublishDate = DateTime.Now
            };
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("title", "Update news"),
                new KeyValuePair<string, string>("content", "Update news"),
                new KeyValuePair<string, string>("publishDate", "09/06/2015")
            });

            context.News.Add(updateNews);
            context.SaveChanges();

            var response = httpClient.PutAsync(string.Format("api/news/{0}", updateNews.Id), content).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            context.News.Remove(updateNews);
            context.SaveChanges();
        }

        [TestMethod]
        public void Put_ShouldReturn400BadRequestOnNullTitle()
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("title", null),
                new KeyValuePair<string, string>("content", "Null title"),
                new KeyValuePair<string, string>("publishDate", "09/06/2015")
            });
            int existingNewsId = 1;
            var response = httpClient.PutAsync(string.Format("api/news/{0}", existingNewsId), content).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Put_ShouldReturn400BadRequestOnNullContent()
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("title", "Null content"),
                new KeyValuePair<string, string>("content", null),  
                new KeyValuePair<string, string>("publishDate", "09/06/2015")
            });
            int existingNewsId = 1;
            var response = httpClient.PutAsync(string.Format("api/news/{0}", existingNewsId), content).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Delete_ShouldReturn200OKOnExistingItem()
        {
            var context = new NewsContext();
            var newNews = new NewsModel()
            {
                Title = "Delete news",
                Content = "Delete news",
                PublishDate = DateTime.Now
            };

            context.News.Add(newNews);
            context.SaveChanges();

            var response = httpClient.DeleteAsync(string.Format("api/news/{0}", newNews.Id)).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void Delete_ShouldReturn400BadRequestOnNonExistingItem()
        {
            int nonExistingNewsId = 20202;
            var response = httpClient.DeleteAsync(string.Format("api/news/{0}", nonExistingNewsId)).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
