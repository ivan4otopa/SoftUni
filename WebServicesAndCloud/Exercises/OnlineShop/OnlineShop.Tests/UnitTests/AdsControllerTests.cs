using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace OnlineShop.Tests.UnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Data;
    using Services.Controllers;
    using System.Threading;
    using System.Net;
    using System.Net.Http;
    using System.Collections.Generic;
    using Services.Models;
    using System.Linq;
    using System.Web.Http;
    using Services.Infrastructure;
    using Models;

    [TestClass]
    public class AdsControllerTests
    {
        private MockContainer mocks;

        [TestInitialize]
        public void Initialize()
        {
            this.mocks = new MockContainer();
            this.mocks.PrepareMocks();
        }

        [TestMethod]
        public void GetAllAds_ShouldReturnAllAdsSortedByTypeIndex()
        {
            var fakeAds = this.mocks.AdRepositoryMock.Object.All();
            var mockContext = new Mock<IOnlineShopData>();
            var mockUserIdProvider = new Mock<IUserIdProvider>();

            mockContext
                .Setup(r => r.Ads.All())
                .Returns(fakeAds);

            var adsController = new AdsController(mockContext.Object, mockUserIdProvider.Object);

            this.SetupController(adsController);

            var response = adsController.Get()
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var adsResponse = response.Content
                .ReadAsAsync<IEnumerable<AdViewModel>>()
                .Result.Select(a => a.Id)
                .ToList();

            var orderedFakeAds = fakeAds
                .OrderByDescending(a => a.Type.Index)
                .ThenByDescending(a => a.PostedOn)
                .Select(a => a.Id)
                .ToList();

            CollectionAssert.AreEqual(orderedFakeAds, adsResponse);
        }

        [TestMethod]
        public void CreateAd_ShouldSuccessfullyAddToRepository()
        {
            var ads = new List<Ad>();
            var fakeUser = this.mocks.ApplicationUserRepositoryMock.Object.All()
                .FirstOrDefault();

            if (fakeUser == null)
            {
                Assert.Fail("Cannot perform test - no users available.");
            }

            this.mocks.AdRepositoryMock
                .Setup(r => r.Add(It.IsAny<Ad>()))
                .Callback((Ad ad) =>
                {
                    ad.Owner = fakeUser;
                    ads.Add(ad);
                });

            var mockContext = new Mock<IOnlineShopData>();

            mockContext
                .Setup(c => c.Ads)
                .Returns(this.mocks.AdRepositoryMock.Object);
            mockContext
                .Setup(c => c.AdTypes)
                .Returns(this.mocks.AdTypeRepositoryMock.Object);
            mockContext
                .Setup(c => c.ApplicationUsers)
                .Returns(this.mocks.ApplicationUserRepositoryMock.Object);
            mockContext
                .Setup(c => c.Categories)
                .Returns(this.mocks.CategoryRepositoryMock.Object);

            var mockIdProvider = new Mock<IUserIdProvider>();

            mockIdProvider
                .Setup(ip => ip.GetUserId())
                .Returns(fakeUser.Id);

            var adsController = new AdsController(mockContext.Object, mockIdProvider.Object);

            this.SetupController(adsController);

            var randomName = Guid.NewGuid().ToString();
            var newAd = new CreateAdBindingModel()
            {
                Name = randomName,
                Price = 555,
                TypeId = 1,
                Description = "Nothing much to say",
                Categories = new[] { 1, 2, 3 }
            };

            var response = adsController.Post(newAd)
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            mockContext.Verify(c => c.SaveChanges(), Times.Once);

            Assert.AreEqual(1, ads.Count);
            Assert.AreEqual(newAd.Name, ads[0].Name);
        }

        [TestMethod]
        public void CloseAdAsOwnerShouldReturn200OK()
        {
            var fakeAds = this.mocks.AdRepositoryMock.Object.All();
            var openAd = fakeAds.FirstOrDefault(a => a.Status == AdStatus.Open);

            if (openAd == null)
            {
                Assert.Fail("Cannot perform test - no open ads available.");
            }

            var adId = openAd.Id;
            var mockContext = new Mock<IOnlineShopData>();

            mockContext
                .Setup(c => c.Ads)
                .Returns(this.mocks.AdRepositoryMock.Object);

            var mockIdProvider = new Mock<IUserIdProvider>();

            mockIdProvider
                .Setup(ip => ip.GetUserId())
                .Returns(openAd.OwnerId);

            var adsController = new AdsController(mockContext.Object, mockIdProvider.Object);

            this.SetupController(adsController);

            var response = adsController.CloseAd(adId)
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            mockContext.Verify(c => c.SaveChanges(), Times.Once);

            Assert.IsTrue(openAd.ClosedOn != null);
            Assert.AreEqual(openAd.Status, AdStatus.Closed);
        }

        [TestMethod]
        public void CloseAdAsNonOwnerShouldReturn401Unauthorized()
        {
            var fakeAds = this.mocks.AdRepositoryMock.Object.All();
            var openAd = fakeAds.FirstOrDefault(a => a.Status == AdStatus.Open);

            if (openAd == null)
            {
                Assert.Fail("Cannot perform test - no open ads available.");
            }

            var adId = openAd.Id;
            var fakeUsers = this.mocks.ApplicationUserRepositoryMock.Object.All();
            var foreignUser = fakeUsers.FirstOrDefault(u => u.Id != openAd.OwnerId);
            var mockContext = new Mock<IOnlineShopData>();

            mockContext
                .Setup(c => c.Ads)
                .Returns(this.mocks.AdRepositoryMock.Object);

            var mockIdProvider = new Mock<IUserIdProvider>();

            mockIdProvider
                .Setup(ip => ip.GetUserId())
                .Returns(foreignUser.Id);

            var adsController = new AdsController(mockContext.Object, mockIdProvider.Object);

            this.SetupController(adsController);

            var response = adsController.CloseAd(adId)
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);

            mockContext.Verify(c => c.SaveChanges(), Times.Never);

            Assert.AreEqual(openAd.Status, AdStatus.Open);
        }

        private void SetupController(AdsController adsController)
        {
            adsController.Request = new HttpRequestMessage();
            adsController.Configuration = new HttpConfiguration();
        }
    }
}
