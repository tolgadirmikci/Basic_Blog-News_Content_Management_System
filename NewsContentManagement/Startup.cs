using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewsContentManagement.Startup))]
namespace NewsContentManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
