namespace ASPNETMVCIdentity.Migrations
{
    using Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web;
    using Microsoft.AspNet.Identity.Owin;

    internal sealed class Configuration : DbMigrationsConfiguration<ASPNETMVCIdentity.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ASPNETMVCIdentity.Models.ApplicationDbContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roleCreateResult = roleManager.Create(new IdentityRole("Administrator"));

            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", roleCreateResult.Errors));
            }

            var user = new ApplicationUser()
            {
                Email = "admin@admin.com",
                UserName = "admin@admin.com"
            };

            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();                 
            var userCreateResult = userManager.Create(user, "1");
            var adminUser = context.Users
                .FirstOrDefault(u => u.UserName == "admin@admin.com");
            var addAdminRoleResult = userManager.AddToRole(adminUser.Id, "Administrator");

            if (!addAdminRoleResult.Succeeded)
            {
                throw new Exception(string.Join("; ", addAdminRoleResult.Errors));
            }
        }
    }
}
