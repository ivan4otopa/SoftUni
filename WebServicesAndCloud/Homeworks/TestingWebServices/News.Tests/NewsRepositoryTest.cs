using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace News.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Transactions;
    using Data.Repositories;
    using Data;
    using System.Collections.Generic;
    using Models;
    using System.Linq;
    using System.Data.Entity.Validation;

    [TestClass]
    public class NewsRepositoryTests
    {
        private static TransactionScope tran;
        private NewsRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();
            this.repository = new NewsRepository(new NewsContext());
        }

        [TestCleanup]
        public void TestCleanup()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void All_ShouldReturnAllNewsItemsCorrectly()
        {
            var actualNews = this.repository.All().ToList();
            var expectedNews = new List<NewsModel>()
            {
                new NewsModel()
                {
                    Id = 1,
                    Title = "Selski subor na ploshtada ot 17:30",
                    Content = "Shte ima kliu - kliu za babichkite",
                    PublishDate = new DateTime(2015, 9, 1)
                },
                new NewsModel()
                {
                    Id = 2,
                    Title = "Razprodajba na kone i muleta subota ot 12:00",
                    Content = "Purvite zakupili poluchavat podaruk - kilimche za pred banqta",
                    PublishDate = new DateTime(2015, 9, 2)
                },
                new NewsModel()
                {
                    Id = 3,
                    Title = "Predstavlenie na cirkova trupa 'Keleshite' ponedelnik ot 17:00",
                    Content = "Na centura",
                    PublishDate = new DateTime(2015, 9, 2)
                }
            };
            var orderedExpectedNews = expectedNews
                .OrderByDescending(n => n.PublishDate)
                .ToList();

            Assert.AreEqual(orderedExpectedNews[0].Id, actualNews[0].Id);
            Assert.AreEqual(orderedExpectedNews[1].Id, actualNews[1].Id);
            Assert.AreEqual(orderedExpectedNews[2].Id, actualNews[2].Id);
        }

        [TestMethod]
        public void Add_ShouldCreateNewNewsAndReturnItOnCorrectData()
        {
            var newNews = new NewsModel()
            {
                Title = "New news",
                Content = "The news is new",
                PublishDate = DateTime.Now
            };

            var returnedNews = this.repository.Add(newNews);
            this.repository.SaveChanges();

            Assert.IsNotNull(returnedNews);
            Assert.AreEqual(newNews.Title, returnedNews.Title);
            Assert.AreEqual(newNews.Content, returnedNews.Content);
            Assert.AreEqual(newNews.PublishDate, returnedNews.PublishDate);
            Assert.IsTrue(returnedNews.Id != 0);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void Add_ShouldThrowExceptionOnNullTitle()
        {
            var newNews = new NewsModel()
            {
                Title = null,
                Content = "Null title",
                PublishDate = DateTime.Now
            };

            this.repository.Add(newNews);
            this.repository.SaveChanges();
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void Add_ShouldThrowExceptionOnNullContent()
        {
            var newNews = new NewsModel()
            {
                Title = "Null content",
                Content = null,
                PublishDate = DateTime.Now
            };

            this.repository.Add(newNews);
            this.repository.SaveChanges();
        }

        [TestMethod]
        public void Update_ShouldModifyEntityOnCorrectData()
        {
            int newsId = 2;
            var updateNews = new NewsModel()
            {
                Title = "Updated title",
                Content = "Updated content",
                PublishDate = DateTime.Now
            };

            this.repository.Update(newsId, updateNews);
            this.repository.SaveChanges();

            var news = this.repository.Find(newsId);

            Assert.AreEqual(updateNews.Title, news.Title);
            Assert.AreEqual(updateNews.Content, news.Content);
            Assert.AreEqual(updateNews.PublishDate, news.PublishDate);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void Update_ShouldThrowExceptionOnNullTitle()
        {
            int newsId = 2;
            var updateNews = new NewsModel()
            {
                Title = null,
                Content = "Null title",
                PublishDate = DateTime.Now
            };

            this.repository.Update(newsId, updateNews);
            this.repository.SaveChanges();
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void Update_ShouldThrowExceptionOnNullContent()
        {
            int newsId = 2;
            var updateNews = new NewsModel()
            {
                Title = "Null content",
                Content = null,
                PublishDate = DateTime.Now
            };

            this.repository.Update(newsId, updateNews);
            this.repository.SaveChanges();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Update_ShouldThrowExceptionOnNonExistingItemUpdate()
        {
            int newsId = 5;
            var updateNews = new NewsModel()
            {
                Title = "Updated title",
                Content = "Updated content",
                PublishDate = DateTime.Now
            };

            this.repository.Update(newsId, updateNews);
            this.repository.SaveChanges();
        }

        [TestMethod]
        public void Delete_ShouldRemoveItemWithExistingId()
        {
            int newsId = 2;            

            this.repository.Delete(newsId);
            this.repository.SaveChanges();

            var news = this.repository.Find(newsId);

            Assert.IsTrue(news == null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Delete_ShouldThrowExceptionOnNonExistantId()
        {
            int newsId = 5;

            this.repository.Delete(newsId);
            this.repository.SaveChanges();
        }
    }
}
