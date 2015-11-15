using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Laptop.App.Startup))]
namespace Laptop.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
