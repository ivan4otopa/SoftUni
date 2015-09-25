namespace OnlineShop.Data
{
    using Repositories;
    using Models;

    public interface IOnlineShopData
    {
        IRepository<Ad> Ads { get; }

        IRepository<AdType> AdTypes { get; }

        IRepository<Category> Categories { get; }

        IRepository<ApplicationUser> ApplicationUsers { get; }

        int SaveChanges();
    }
}
