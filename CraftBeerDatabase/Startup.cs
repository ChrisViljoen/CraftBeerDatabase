using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CraftBeerDatabase.Startup))]
namespace CraftBeerDatabase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
