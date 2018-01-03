using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NiseWorld.Startup))]
namespace NiseWorld
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
