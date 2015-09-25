using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Ninject;
using System.Reflection;
using OnlineShop.Services.Infrastructure;
using OnlineShop.Data;
using System.Web.Http;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using System.Data.Entity;

[assembly: OwinStartup(typeof(OnlineShop.Services.Startup))]

namespace OnlineShop.Services
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<IUserIdProvider>().To<AspNetUserIdProvider>();
            kernel.Bind<IOnlineShopData>().To<OnlineShopData>();
            kernel.Bind<DbContext>().To<OnlineShopContext>();

            var httpConfig = new HttpConfiguration();

            WebApiConfig.Register(httpConfig);

            app.UseNinjectMiddleware(() => kernel)
                .UseNinjectWebApi(httpConfig);
        }
    }
}
