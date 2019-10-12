using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GeckoTracker.WebMVC.Startup))]
namespace GeckoTracker.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
