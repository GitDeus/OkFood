using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OkFood.Startup))]
namespace OkFood
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
