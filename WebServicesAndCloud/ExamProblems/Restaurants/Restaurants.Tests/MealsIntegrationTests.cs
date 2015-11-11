namespace Restaurants.Tests
{
    using Microsoft.Owin.Testing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Owin;
    using Data;
    using Services;
    using System.Net.Http;
    using System.Web.Http;
    using Models;
    using System.Net;
    using System.Collections.Generic;

    [TestClass]
    public class MealsIntegrationTests
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
        public void Edit_ShouldReturn400BadRequestWhenModelIsNull()
        {
            var context = new RestaurantsContext();
            var newTown = new Town()
            {
                Name = "New town"
            };

            context.Towns.Add(newTown);
            context.SaveChanges();

            var newRestaurant = new Restaurant()
            {
                Name = "New restaurant",
                TownId = newTown.Id
            };

            context.Restaurants.Add(newRestaurant);
            context.SaveChanges();

            var newMeal = new Meal()
            {
                Name = "New meal",
                Price = 4.99M,
                RestaurantId = newRestaurant.Id,
                TypeId = 3
            };

            context.Meals.Add(newMeal);
            context.SaveChanges();

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", "aaaaa")
            });

            var response = httpClient.PutAsync(string.Format("api/meals/{0}", newMeal.Id), content).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
