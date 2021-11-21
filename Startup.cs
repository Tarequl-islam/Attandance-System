using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AttandanceSystem.Startup))]
namespace AttandanceSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
