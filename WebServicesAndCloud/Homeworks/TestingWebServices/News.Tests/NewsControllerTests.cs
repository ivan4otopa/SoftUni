using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace News.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Services.Controllers;
    using System.Net.Http;
    using System.Web.Http;
    using Moq;
    using Data;
    using System.Net;
    using System.Threading;
    using System.Collections.Generic;
    using Models;
    using System.Linq;
    using Services.Models;
    using System.Data.Entity.Validation;

    [TestClass]
    public class NewsControllerTests
    {
        private MockContainer mocks;

        [TestInitialize]
        public void Initialize()
        {
            this.mocks = new MockContainer();
            this.mocks.SetupFakeNews();
        }

        [TestMethod]
        public void Get_ShouldReturn200OKAndRetrieveAllNewsItemsCorrectly()
        {
            var fakeNews = this.mocks.NewsRepositoryMock.Object.All();
            var mockContext = new Mock<INewsData>();

            mockContext
                .Setup(c => c.News.All())
                .Returns(fakeNews);

            var newsController = new NewsController(mockContext.Object);

            this.SetupController(newsController);

            var response = newsController.Get()
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var newsResponse = response.Content
                .ReadAsAsync<IEnumerable<NewsModel>>()
                .Result.Select(n => n.Id)
                .ToList();

            var orderedFakeNews = fakeNews
                .OrderByDescending(n => n.PublishDate)
                .Select(fn => fn.Id)
                .ToList();

            CollectionAssert.AreEqual(orderedFakeNews, newsResponse);
        }

        [TestMethod]
        public void Post_ShouldReturn201CreatedAndCreateNewNewsAndReturnIt()
        {
            var news = new List<NewsModel>();

            this.mocks.NewsRepositoryMock
                .Setup(r => r.Add(It.IsAny<NewsModel>()))
                .Callback((NewsModel newsModel) =>
                {
                    news.Add(newsModel);
                });

            var mockContext = new Mock<INewsData>();

            mockContext
                .Setup(c => c.News)
                .Returns(this.mocks.NewsRepositoryMock.Object);

            var newsController = new NewsController(mockContext.Object);

            this.SetupController(newsController);

            var newNews = new PostNewsBindingModel()
            {
                Title = "New News",
                Content = "The news is new"
            };
            var response = newsController.Post(newNews)
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

            var returnedNews = response.Content
                .ReadAsAsync<NewsModel>()
                .Result;

            Assert.IsTrue(returnedNews != null);
            Assert.AreEqual(newNews.Title, returnedNews.Title);
            Assert.AreEqual(newNews.Content, returnedNews.Content);
        }

        [TestMethod]
        public void Post_ShouldReturn400BadRequestOnNullTitle()
        {
            var news = new List<NewsModel>();

            this.mocks.NewsRepositoryMock
                .Setup(r => r.Add(It.IsAny<NewsModel>()))
                .Callback((NewsModel newsModel) =>
                {
                    news.Add(newsModel);
                });

            var mockContext = new Mock<INewsData>();

            mockContext
                .Setup(c => c.News)
                .Returns(this.mocks.NewsRepositoryMock.Object);

            var newsController = new NewsController(mockContext.Object);

            this.SetupController(newsController);            

            var newNews = new PostNewsBindingModel()
            {
                Title = null,
                Content = "Null title"
            };

            newsController.Validate(newNews);

            var response = newsController.Post(newNews)
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Post_ShouldReturn400BadRequestOnNullContent()
        {
            var news = new List<NewsModel>();

            this.mocks.NewsRepositoryMock
                .Setup(r => r.Add(It.IsAny<NewsModel>()))
                .Callback((NewsModel newsModel) =>
                {
                    news.Add(newsModel);
                });

            var mockContext = new Mock<INewsData>();

            mockContext
                .Setup(c => c.News)
                .Returns(this.mocks.NewsRepositoryMock.Object);

            var newsController = new NewsController(mockContext.Object);

            this.SetupController(newsController);

            var newNews = new PostNewsBindingModel()
            {
                Title = "Null content",
                Content = null
            };

            newsController.Validate(newNews);

            var response = newsController.Post(newNews)
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Put_ShouldModifyExistingItemAndReturn200OKOnCorrectData()
        {
            var fakeNews = this.mocks.NewsRepositoryMock.Object.All();
            int existingNewsId = 1;

            this.mocks.NewsRepositoryMock
                .Setup(r => r.Update(It.IsAny<NewsModel>()))
                .Callback((NewsModel newsModel) =>
                {
                    var news = fakeNews.FirstOrDefault(fn => fn.Id == existingNewsId);

                    news.Title = newsModel.Title;
                    news.Content = newsModel.Content;
                    news.PublishDate = newsModel.PublishDate;
                });

            var mockContext = new Mock<INewsData>();

            mockContext
                .Setup(c => c.News)
                .Returns(this.mocks.NewsRepositoryMock.Object);

            var newsController = new NewsController(mockContext.Object);

            this.SetupController(newsController);

            var updateNews = new PutNewsBindingModel()
            {
                Title = "Updated news",
                Content = "Updated content",
                PublishDate = new DateTime(2015, 9, 5)
            };
            var response = newsController.Put(existingNewsId, updateNews)
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var updatedNews = response.Content
                .ReadAsAsync<NewsModel>()
                .Result;

            Assert.AreEqual(updateNews.Title, updatedNews.Title);
            Assert.AreEqual(updateNews.Content, updatedNews.Content);
            Assert.AreEqual(updateNews.PublishDate, updatedNews.PublishDate);
        }

        [TestMethod]
        public void Put_ShouldReturn400BadRequestOnNullTitle()
        {
            var fakeNews = this.mocks.NewsRepositoryMock.Object.All();
            int existingNewsId = 1;

            this.mocks.NewsRepositoryMock
                .Setup(r => r.Update(It.IsAny<NewsModel>()))
                .Callback((NewsModel newsModel) =>
                {
                    var news = fakeNews.FirstOrDefault(fn => fn.Id == existingNewsId);

                    news.Title = newsModel.Title;
                    news.Content = newsModel.Content;
                    news.PublishDate = newsModel.PublishDate;
                });

            var mockContext = new Mock<INewsData>();

            mockContext
                .Setup(c => c.News)
                .Returns(this.mocks.NewsRepositoryMock.Object);

            var newsController = new NewsController(mockContext.Object);

            this.SetupController(newsController);

            var updateNews = new PutNewsBindingModel()
            {
                Title = null,
                Content = "Null title",
                PublishDate = new DateTime(2015, 9, 5)
            };

            newsController.Validate(updateNews);

            var response = newsController.Put(existingNewsId, updateNews)
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Put_ShouldReturn400BadRequestOnNullContent()
        {
            var fakeNews = this.mocks.NewsRepositoryMock.Object.All();
            int existingNewsId = 1;

            this.mocks.NewsRepositoryMock
                .Setup(r => r.Update(It.IsAny<NewsModel>()))
                .Callback((NewsModel newsModel) =>
                {
                    var news = fakeNews.FirstOrDefault(fn => fn.Id == existingNewsId);

                    news.Title = newsModel.Title;
                    news.Content = newsModel.Content;
                    news.PublishDate = newsModel.PublishDate;
                });

            var mockContext = new Mock<INewsData>();

            mockContext
                .Setup(c => c.News)
                .Returns(this.mocks.NewsRepositoryMock.Object);

            var newsController = new NewsController(mockContext.Object);

            this.SetupController(newsController);

            var updateNews = new PutNewsBindingModel()
            {
                Title = "Null content",
                Content = null,
                PublishDate = new DateTime(2015, 9, 5)
            };

            newsController.Validate(updateNews);

            var response = newsController.Put(existingNewsId, updateNews)
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Put_TryingToModifyNonExistantItemShouldReturn400BadRequest()
        {
            var fakeNews = this.mocks.NewsRepositoryMock.Object.All();
            int nonExistingNewsId = 5;

            this.mocks.NewsRepositoryMock
                .Setup(r => r.Update(It.IsAny<NewsModel>()))
                .Callback((NewsModel newsModel) =>
                {
                    var news = fakeNews.FirstOrDefault(fn => fn.Id == nonExistingNewsId);

                    news.Title = newsModel.Title;
                    news.Content = newsModel.Content;
                    news.PublishDate = newsModel.PublishDate;
                });

            var mockContext = new Mock<INewsData>();

            mockContext
                .Setup(c => c.News)
                .Returns(this.mocks.NewsRepositoryMock.Object);

            var newsController = new NewsController(mockContext.Object);

            this.SetupController(newsController);

            var updateNews = new PutNewsBindingModel()
            {
                Title = "Updated news",
                Content = "Updated content",
                PublishDate = new DateTime(2015, 9, 5)
            };
            var response = newsController.Put(nonExistingNewsId, updateNews)
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Delete_ShouldDeleteExistingItemAndReturn200Ok()
        {
            var news = this.mocks.NewsRepositoryMock.Object.All().ToList();
            int existingNewsId = 1;

            this.mocks.NewsRepositoryMock
                .Setup(r => r.Delete(It.IsAny<NewsModel>()))
                .Callback((NewsModel newsModel) =>
                {
                    news.Remove(newsModel);
                });

            var mockContext = new Mock<INewsData>();

            mockContext
                .Setup(c => c.News)
                .Returns(this.mocks.NewsRepositoryMock.Object);

            var newsController = new NewsController(mockContext.Object);

            this.SetupController(newsController);

            var response = newsController.Delete(existingNewsId)
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void Delete_ShouldReturn400BadRequestOnNonExistingItem()
        {
            var news = this.mocks.NewsRepositoryMock.Object.All().ToList();
            int nonExistingNewsId = 5;

            this.mocks.NewsRepositoryMock
                .Setup(r => r.Delete(It.IsAny<NewsModel>()))
                .Callback((NewsModel newsModel) =>
                {
                    news.Remove(newsModel);
                });

            var mockContext = new Mock<INewsData>();

            mockContext
                .Setup(c => c.News)
                .Returns(this.mocks.NewsRepositoryMock.Object);

            var newsController = new NewsController(mockContext.Object);

            this.SetupController(newsController);

            var response = newsController.Delete(nonExistingNewsId)
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        private void SetupController(NewsController newsController)
        {
            newsController.Request = new HttpRequestMessage();
            newsController.Configuration = new HttpConfiguration();
        }
    }
}
