using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(wwwroot.Startup))]
namespace wwwroot
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
