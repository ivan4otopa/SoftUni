namespace OnlineShop.Tests
{
    using Moq;
    using Data.Repositories;
    using Models;
    using System.Collections.Generic;
    using System;
    using System.Linq;

    public class MockContainer
    {
        public Mock<IRepository<Ad>> AdRepositoryMock { get; set; }

        public Mock<IRepository<AdType>> AdTypeRepositoryMock { get; set; }

        public Mock<IRepository<ApplicationUser>> ApplicationUserRepositoryMock { get; set; }

        public Mock<IRepository<Category>> CategoryRepositoryMock { get; set; }

        public void PrepareMocks()
        {
            this.SetupFakeAds();
            this.SetupFakeAdTypes();
            this.SetupFakeUsers();
            this.SetupFakeCategories();
        }

        private void SetupFakeAds()
        {
            var adTypes = new List<AdType>
            {
                new AdType()
                {
                    Name = "Normal",
                    PricePerDay = 3.99m,
                    Index = 100
                },
                new AdType()
                {
                    Name = "Premium",
                    PricePerDay = 5.99m,
                    Index = 200
                },
                new AdType()
                {
                    Name = "Diamond",
                    PricePerDay = 9.99m,
                    Index = 300
                }
            };

            var user = new ApplicationUser()
            {
                UserName = "Petko",
                Id = "asd"
            };

            var fakeAds = new List<Ad>()
            {
                new Ad()
                {
                    Id = 1,
                    Name = "asd",
                    Description = "asd",
                    Status = AdStatus.Open,
                    Price = 3.55M,
                    PostedOn = DateTime.Now.AddDays(-5),
                    Owner = user,
                    Type = adTypes[0]
                },
                new Ad()
                {
                    Id = 2,
                    Name = "asf",
                    Description = "asf",
                    Status = AdStatus.Closed,
                    Price = 16.98M,
                    PostedOn = DateTime.Now.AddDays(-22),
                    Owner = user,
                    Type = adTypes[1]
                },
                new Ad()
                {
                    Id = 3,
                    Name = "asda",
                    Description = "asda",
                    Status = AdStatus.Open,
                    Price = 12.22M,
                    PostedOn = DateTime.Now,
                    Owner = user,
                    Type = adTypes[2]
                }
            };

            this.AdRepositoryMock = new Mock<IRepository<Ad>>();
            this.AdRepositoryMock
                .Setup(r => r.All())
                .Returns(fakeAds.AsQueryable());
            this.AdRepositoryMock
                .Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    return fakeAds.FirstOrDefault(a => a.Id == id);
                });
        }

        private void SetupFakeAdTypes()
        {
            var fakeAdTypes = new List<AdType>
            {
                new AdType()
                {
                    Id = 1,
                    Name = "Normal",
                    PricePerDay = 3.99m,
                    Index = 100
                },
                new AdType()
                {
                    Id = 2,
                    Name = "Premium",
                    PricePerDay = 5.99m,
                    Index = 200
                },
                new AdType()
                {
                    Id = 3,
                    Name = "Diamond",
                    PricePerDay = 9.99m,
                    Index = 300
                }
            };

            this.AdTypeRepositoryMock = new Mock<IRepository<AdType>>();
            this.AdTypeRepositoryMock
                .Setup(r => r.All())
                .Returns(fakeAdTypes.AsQueryable());
            this.AdTypeRepositoryMock
                .Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    return fakeAdTypes.FirstOrDefault(at => at.Id == id);
                });
        }

        private void SetupFakeUsers()
        {
            var fakeUsers = new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    Id = "asd",
                    UserName = "Petko"
                },
                new ApplicationUser()
                {
                    Id = "asdf",
                    UserName = "Dragan"
                }
            };

            this.ApplicationUserRepositoryMock = new Mock<IRepository<ApplicationUser>>();
            this.ApplicationUserRepositoryMock
                .Setup(r => r.All())
                .Returns(fakeUsers.AsQueryable());
            this.ApplicationUserRepositoryMock
                .Setup(r => r.Find(It.IsAny<string>()))
                .Returns((string id) =>
                {
                    return fakeUsers.FirstOrDefault(at => at.Id == id);
                });
        }

        private void SetupFakeCategories()
        {
            var fakeCategories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Business"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Garden"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Toys"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Pleasure"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Electronics"
                },
                new Category()
                {
                    Id = 6,
                    Name = "Clothes"
                }
            };

            this.CategoryRepositoryMock = new Mock<IRepository<Category>>();
            this.CategoryRepositoryMock
                .Setup(r => r.All())
                .Returns(fakeCategories.AsQueryable());
            this.CategoryRepositoryMock
                .Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    return fakeCategories.FirstOrDefault(c => c.Id == id);
                });
        }
    }
}
