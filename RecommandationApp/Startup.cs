using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecommandationApp.Startup))]
namespace RecommandationApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
