namespace Restaurants.Tests.IntegrationTests
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
    using System.Linq;
    using EntityFramework.Extensions;

    [TestClass]
    public class MealsIntegrationTests
    {
        private int townId;
        private int firstMealTypeId;
        private int secondMealTypeId;
        private int restaurantId;
        private int mealId;
        private TestServer httpTestServer;
        private HttpClient httpClient;

        [TestInitialize]
        public void TestInit()
        {
            this.httpTestServer = TestServer.Create(appBuilder =>
            {
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);

                var startup = new Startup();
                startup.Configuration(appBuilder);

                appBuilder.UseWebApi(config);
            });
            this.httpClient = this.httpTestServer.HttpClient;

            CleanDatabase();

            this.SeedDatabase();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.httpTestServer.Dispose();
        }

        [TestMethod]
        public void Edit_ShouldReturn400BadRequestWhenModelIsNull()
        {
            var loginData = this.Login("uti");

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + loginData.Access_Token);

            var response = httpClient.PutAsync(string.Format("api/meals/{0}", mealId), null).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Edit_ShouldReturn400BadRequestWhenNameIsNull()
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", null),
                new KeyValuePair<string, string>("price", "2.5"),
                new KeyValuePair<string, string>("typeId", this.secondMealTypeId.ToString())
            });
            var loginData = this.Login("uti");

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + loginData.Access_Token);

            var response = httpClient.PutAsync(string.Format("api/meals/{0}", mealId), content).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Edit_ShouldReturn400BadRequestWhenNameIsEmpty()
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", ""),
                new KeyValuePair<string, string>("price", "2.5"),
                new KeyValuePair<string, string>("typeId", this.secondMealTypeId.ToString())
            });
            var loginData = this.Login("uti");

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + loginData.Access_Token);

            var response = httpClient.PutAsync(string.Format("api/meals/{0}", mealId), content).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Edit_ShouldReturn400BadRequestWhenMealTypeDoesNotExist()
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", "Update name"),
                new KeyValuePair<string, string>("price", "2.5"),
                new KeyValuePair<string, string>("typeId", this.secondMealTypeId.ToString() + "1")
            });
            var loginData = this.Login("uti");

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + loginData.Access_Token);

            var response = httpClient.PutAsync(string.Format("api/meals/{0}", mealId), content).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Edit_ShouldReturn404NotFoundWhenMealDoesNotExist()
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", "Update name"),
                new KeyValuePair<string, string>("price", "2.5"),
                new KeyValuePair<string, string>("typeId", this.secondMealTypeId.ToString())
            });
            var loginData = this.Login("uti");

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + loginData.Access_Token);

            var response = httpClient.PutAsync(string.Format("api/meals/{0}", mealId + 1), content).Result;

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public void Edit_ShouldReturn401UnauthorizedWhenUserIsNotRestaurantOwner()
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", "Update name"),
                new KeyValuePair<string, string>("price", "2.5"),
                new KeyValuePair<string, string>("typeId", this.secondMealTypeId.ToString())
            });
            var loginData = this.Login("ivan");

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + loginData.Access_Token);

            var response = httpClient.PutAsync(string.Format("api/meals/{0}", mealId), content).Result;

            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [TestMethod]
        public void Edit_ShouldReturn401UnauthorizedWhenThereIsNoLoggedInUser()
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", "Update name"),
                new KeyValuePair<string, string>("price", "2.5"),
                new KeyValuePair<string, string>("typeId", this.secondMealTypeId.ToString())
            });

            var response = httpClient.PutAsync(string.Format("api/meals/{0}", mealId), content).Result;

            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [TestMethod]
        public void Edit_ShouldReturn200OKWhenOperationIsSuccessful()
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", "Update name"),
                new KeyValuePair<string, string>("price", "2.5"),
                new KeyValuePair<string, string>("typeId", this.secondMealTypeId.ToString())
            });
            var loginData = this.Login("uti");

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + loginData.Access_Token);

            var response = httpClient.PutAsync(string.Format("api/meals/{0}", mealId), content).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        private static void CleanDatabase()
        {
            using (var context = new RestaurantsContext())
            {
                context.Meals.Delete();
                context.Restaurants.Delete();
                context.Users.Delete();
                context.MealTypes.Delete();
                context.Towns.Delete();
                context.SaveChanges();
            }
        }

        private LoginData Login(string username)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("username", username),
                new KeyValuePair<string,string>("password", "123456"),
                new KeyValuePair<string, string>("grant_type", "password")
            });

            var response = httpClient.PostAsync("api/account/login", content).Result;

            return response.Content.ReadAsAsync<LoginData>().Result;
        }

        private void Register()
        {
            var firstUserContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", "uti"),
                new KeyValuePair<string, string>("password", "123456"),
                new KeyValuePair<string, string>("confirmPassword", "123456"),
                new KeyValuePair<string, string>("email", "uti@kanal1.com")
            });

            var firstUserResponse = this.httpClient.PostAsync("api/account/register", firstUserContent).Result;

            var secondUserContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", "ivan"),
                new KeyValuePair<string, string>("password", "123456"),
                new KeyValuePair<string, string>("confirmPassword", "123456"),
                new KeyValuePair<string, string>("email", "ivan@softuni.com")
            });

            var secondUserResponse = this.httpClient.PostAsync("api/account/register", secondUserContent).Result;
        }

        private void SeedDatabase()
        {
            this.Register();
            this.SeedTown();
            var loginData = this.Login("uti");
            this.SeedRestaurant(loginData);
            this.SeedMealTypes();
            this.SeedMeal();
        }

        private void SeedTown()
        {
            using (var context = new RestaurantsContext())
            {
                var newTown = new Town()
                {
                    Name = "New town"
                };

                context.Towns.Add(newTown);
                context.SaveChanges();


                this.townId = newTown.Id;
            }
        }

        private void SeedRestaurant(LoginData loginData)
        {
            using (var context = new RestaurantsContext())
            {
                var newRestaurant = new Restaurant()
                {
                    Name = "New restaurant",
                    TownId = townId,
                    OwnerId = context.Users.FirstOrDefault(u => u.UserName == loginData.Username).Id
                };

                context.Restaurants.Add(newRestaurant);
                context.SaveChanges();

                this.restaurantId = newRestaurant.Id;
            }
        }

        private void SeedMealTypes()
        {
            using (var context = new RestaurantsContext())
            {
                var firstNewMealType = new MealType
                {
                    Name = "Salad",
                    Order = 10
                };

                var secondNewMealType = new MealType
                {
                    Name = "Soup",
                    Order = 20
                };

                context.MealTypes.Add(firstNewMealType);
                context.MealTypes.Add(secondNewMealType);
                context.SaveChanges();

                this.firstMealTypeId = firstNewMealType.Id;
                this.secondMealTypeId = secondNewMealType.Id;
            }
        }

        private void SeedMeal()
        {
            using (var context = new RestaurantsContext())
            {
                var newMeal = new Meal()
                {
                    Name = "New meal",
                    Price = 4.99M,
                    RestaurantId = restaurantId,
                    TypeId = firstMealTypeId
                };

                context.Meals.Add(newMeal);
                context.SaveChanges();

                this.mealId = newMeal.Id;
            }
        }
    }
}
