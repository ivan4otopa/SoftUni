namespace Restaurants.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Owin.Testing;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Restaurants.Services;
    using Owin;
    using Restaurants.Data;
    using Restaurants.Models;
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

        [TestMethod]
        public void Edit_ShouldReturn400BadRequestWhenNullDataIsPassed()
        {
            var context = new RestaurantsContext();

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", "Svinska Parjola"),
                new KeyValuePair<string, string>("restaurantid", "1"),
                new KeyValuePair<string, string>("typeid", "3"),
                new KeyValuePair<string, string>("price", "5.55")
            });

            var postResponse = httpClient.PostAsync("api/meals", content).Result;

            Assert.AreEqual(HttpStatusCode.Created, postResponse.StatusCode);
        }
    }
}
