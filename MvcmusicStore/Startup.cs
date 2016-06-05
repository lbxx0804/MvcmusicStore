using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcmusicStore.Startup))]
namespace MvcmusicStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
