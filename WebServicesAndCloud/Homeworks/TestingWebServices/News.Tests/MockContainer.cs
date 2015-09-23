namespace News.Tests
{
    using Moq;
    using Data.Repositories;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MockContainer
    {
        public Mock<IGenericRepository<NewsModel>> NewsRepositoryMock { get; set; }

        public void SetupFakeNews()
        {
            var fakeNews = new List<NewsModel>()
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

            this.NewsRepositoryMock = new Mock<IGenericRepository<NewsModel>>();
            this.NewsRepositoryMock
                .Setup(r => r.All())
                .Returns(fakeNews.AsQueryable());
            this.NewsRepositoryMock
                .Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    return fakeNews.FirstOrDefault(fn => fn.Id == id);
                });
        }
    }
}
