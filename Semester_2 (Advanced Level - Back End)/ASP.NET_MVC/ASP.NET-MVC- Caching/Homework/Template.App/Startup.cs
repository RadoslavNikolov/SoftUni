using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Template.App.Startup))]
namespace Template.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
