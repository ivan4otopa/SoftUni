namespace OnlineShop.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using OnlineShop.Data.Migrations;
    using OnlineShop.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class OnlineShopContext : IdentityDbContext<ApplicationUser>
    {
        public OnlineShopContext()
            : base("OnlineShopContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OnlineShopContext, Configuration>());
        }

        public virtual IDbSet<Ad> Ads { get; set; }

        public virtual IDbSet<AdType> AdTypes { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public static OnlineShopContext Create()
        {
            return new OnlineShopContext();
        }
    }
}