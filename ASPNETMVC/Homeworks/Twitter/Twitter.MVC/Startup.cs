using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Twitter.MVC.Startup))]
namespace Twitter.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
