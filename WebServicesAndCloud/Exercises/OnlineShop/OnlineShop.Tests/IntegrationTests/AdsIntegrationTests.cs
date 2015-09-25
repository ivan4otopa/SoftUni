namespace OnlineShop.Tests.IntegrationTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Owin.Testing;
    using System.Net.Http;
    using System.Web.Http;
    using Services;
    using Owin;
    using Data;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Collections.Generic;
    using EntityFramework.Extensions;

    [TestClass]
    public class AdsIntegrationTests
    {
        private const string TestUserUsername = "petko";
        private const string TestUserPassword = "Petko0o!";

        private static TestServer httpTestServer;
        private static HttpClient httpClient;
        
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            httpTestServer = TestServer.Create(appBuilder =>
            {
                var config = new HttpConfiguration();

                WebApiConfig.Register(config);

                var startup = new Startup();

                startup.Configuration(appBuilder);
                appBuilder.UseWebApi(config);
            });

            httpClient = httpTestServer.HttpClient;
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            if (httpTestServer != null)
            {
                httpTestServer.Dispose();
            }

            CleanDatabase();
        }

        [TestInitialize]
        private static void SeedDatabase()
        {
            var context = new OnlineShopContext();
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(userStore);

            var user = new ApplicationUser()
            {
                UserName = TestUserUsername,
                Email = "parakash@yahoo.in"
            };

            var result = userManager.CreateAsync(user, TestUserPassword).Result;

            if (!result.Succeeded)
            {
                Assert.Fail(string.Join(Environment.NewLine, result.Errors));
            }

            SeedCategories(context);
            SeedAdTypes(context);
        }

        [TestMethod]
        public void TestMethod1()
        {
        }

        private static void CleanDatabase()
        {
            var context = new OnlineShopContext();

            context.Ads.Delete();
            context.AdTypes.Delete();
            context.Categories.Delete();
            context.Users.Delete();
        }

        private static List<AdType> SeedAdTypes(OnlineShopContext context)
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

            foreach (var adType in adTypes)
            {
                context.AdTypes.Add(adType);
            }

            context.SaveChanges();

            return adTypes;
        }

        private static List<Category> SeedCategories(OnlineShopContext context)
        {
            var categories = new List<Category>()
            {
                new Category() {Name = "Business"},
                new Category() {Name = "Garden"},
                new Category() {Name = "Toys"},
                new Category() {Name = "Pleasure"},
                new Category() {Name = "Electronics"},
                new Category() {Name = "Clothes"}
            };

            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }

            context.SaveChanges();

            return categories;
        }
    }
}
