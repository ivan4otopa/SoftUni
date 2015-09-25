namespace Restaurants.Data.UnitOfWork
{
    using Restaurants.Models;
    using Restaurants.Data.Repositories;

    using Microsoft.AspNet.Identity;

    public interface IRestaurantsData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Restaurant> Restaurants { get; }

        IRepository<Meal> Meals { get; }

        IRepository<MealType> MealTypes { get; }

        IRepository<Order> Orders { get; }

        IRepository<Rating> Ratings { get; }

        IRepository<Town> Towns { get; }

        void SaveChanges();
    }
}
