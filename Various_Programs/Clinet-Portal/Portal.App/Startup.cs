using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Portal.App.Startup))]
namespace Portal.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
